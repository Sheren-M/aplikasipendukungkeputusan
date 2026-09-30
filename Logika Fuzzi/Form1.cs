
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Logika_Fuzzi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ================= RESET =================
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var tb in new[]
            {
                txtT1, txtT2, txtT3, txtT4, txtT5, txtUTS, txtUAS
            })
            {
                tb.Text = string.Empty;
            }

            lblAvgValue.Text = "-";
            lblFinalValue.Text = "-";
            lblCategoryValue.Text = "-";
        }

        // ================= HITUNG NILAI =================
        private void btnHitung_Click(object sender, EventArgs e)
        {
            if (!TryGetValue(txtT1.Text, true, out double t1)) return;
            if (!TryGetValue(txtT2.Text, true, out double t2)) return;
            if (!TryGetValue(txtT3.Text, true, out double t3)) return;
            if (!TryGetValue(txtT4.Text, true, out double t4)) return;
            if (!TryGetValue(txtT5.Text, true, out double t5)) return;
            if (!TryGetValue(txtUTS.Text, true, out double uts)) return;
            if (!TryGetValue(txtUAS.Text, true, out double uas)) return;

            // Menghitung rata-rata 5 tugas
            double avgTugas = (t1 + t2 + t3 + t4 + t5) / 5.0;
            lblAvgValue.Text = avgTugas.ToString("0.##");

            // Menghitung nilai akhir berdasarkan bobot
            double finalScore =
                (avgTugas * 0.50) +
                (uts * 0.20) +
                (uas * 0.30);

            lblFinalValue.Text = finalScore.ToString("0.##");

            // Proses fuzzy dan defuzzifikasi
            string category = FuzzyInfer(
                avgTugas, uts, uas, finalScore, out double crisp
            );

            lblCategoryValue.Text =
                $"{category} (crisp={crisp:0.##})";
        }

        // ================= VALIDASI INPUT =================
        private bool TryGetValue(
            string raw,
            bool allowEmptyAsZero,
            out double value)
        {
            value = 0;

            if (string.IsNullOrWhiteSpace(raw))
            {
                if (allowEmptyAsZero)
                {
                    value = 0;
                    return true;
                }

                MessageBox.Show(
                    "Nilai tidak boleh kosong.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (!double.TryParse(raw, out value))
            {
                MessageBox.Show(
                    "Masukkan angka yang valid antara 0 sampai 100.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (value < 0 || value > 100)
            {
                MessageBox.Show(
                    "Nilai harus berada antara 0 sampai 100.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        // ================= FUNGSI KEANGGOTAAN =================
        private double Tri(double x, double a, double b, double c)
        {
            // Bahu kiri: Rendah
            if (a == b)
            {
                if (x <= b) return 1;
                if (x >= c) return 0;

                return (c - x) / (c - b);
            }

            // Bahu kanan: Tinggi
            if (b == c)
            {
                if (x <= a) return 0;
                if (x >= b) return 1;

                return (x - a) / (b - a);
            }

            // Segitiga biasa: Sedang
            if (x <= a || x >= c) return 0;
            if (x == b) return 1;

            if (x < b)
                return (x - a) / (b - a);

            return (c - x) / (c - b);
        }

        // ================= KEANGGOTAAN INPUT =================
        private (double low, double med, double high)
            InputMembership(double x)
        {
            double low = Tri(x, 0, 0, 50);
            double med = Tri(x, 30, 50, 70);
            double high = Tri(x, 50, 100, 100);

            return (low, med, high);
        }

        // ================= KEANGGOTAAN OUTPUT =================
        private double Output_A(double x)
        {
            return Tri(x, 60, 85, 100);
        }

        private double Output_B(double x)
        {
            return Tri(x, 40, 60, 80);
        }

        private double Output_C(double x)
        {
            return Tri(x, 0, 25, 55);
        }

        // ================= INFERENSI FUZZY MAMDANI =================
        private string FuzzyInfer(
            double tugasAvg,
            double uts,
            double uas,
            double finalScore,
            out double crispOutput)
        {
            // Tahap 1: Fuzzifikasi
            var t = InputMembership(tugasAvg);
            var u = InputMembership(uts);
            var s = InputMembership(uas);
            var f = InputMembership(finalScore);

            // Tahap 2: Aturan fuzzy IF-THEN
            double r1 = f.high;
            double r2 = f.med;
            double r3 = f.low;

            double r4 = Min(t.high, u.high, s.high);
            double r5 = Min(t.low, u.low, s.low);
            double r6 = Min(u.high, s.high);
            double r7 = Math.Max(u.low, s.low);
            double r8 = Min(t.med, Math.Max(u.med, s.med));
            double r9 = Min(t.high, f.med);
            double r10 = Math.Max(
                f.high,
                Min(u.high, t.med)
            );

            // Menggabungkan kekuatan aturan per kategori
            double alphaA = Max(r1, r4, r6, r10);
            double alphaB = Max(r2, r8, r9);
            double alphaC = Max(r3, r5, r7);

            // Tahap 3: Agregasi output
            double step = 1.0;
            double num = 0.0;
            double den = 0.0;

            for (double x = 0; x <= 100; x += step)
            {
                double muA = Math.Min(alphaA, Output_A(x));
                double muB = Math.Min(alphaB, Output_B(x));
                double muC = Math.Min(alphaC, Output_C(x));

                double muAgg = Math.Max(
                    muA,
                    Math.Max(muB, muC)
                );

                num += x * muAgg;
                den += muAgg;
            }

            // Tahap 4: Defuzzifikasi centroid
            if (den == 0)
            {
                crispOutput = Math.Round(finalScore, 2);
            }
            else
            {
                crispOutput = Math.Round(num / den, 2);
            }


            // Tahap 5: Penentuan kategori berdasarkan
            // derajat keanggotaan hasil centroid
            double mA = Output_A(crispOutput);
            double mB = Output_B(crispOutput);
            double mC = Output_C(crispOutput);

            if (mA >= mB && mA >= mC)
            {
                return "A (Tinggi)";
            }
            else if (mB >= mA && mB >= mC)
            {
                return "B (Sedang)";
            }
            else
            {
                return "C (Cukup)";
            }
        }

        // ================= OPERATOR FUZZY =================
        private double Min(params double[] values)
        {
            return values.Min();
        }

        private double Max(params double[] values)
        {
            return values.Max();
        }

        // ================= INPUT ANGKA SAJA =================
        private void Txt_DigitsOnly(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            TextBox tb = sender as TextBox;

            if (e.KeyChar == '.' &&
                tb != null &&
                tb.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
    }
}