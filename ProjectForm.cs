using IntervalMergerApp;
using Moq;
using System.Windows.Forms;

namespace Lab03_Variant24_Lisnichuk_
{
    public partial class ProjectForm : Form
    {
        public List<Interval> intervals;
        public Random random;
        public ProjectForm()
        {
            InitializeComponent();
            random = new Random();
            intervals = new List<Interval>();
            btnGenerate.Click += btnGenerate_Click;
            btnRunBruteForce.Click += btnRunBruteForce_Click;
            btnRunOptimized.Click += btnRunOptimized_Click;
            btnCompareTime.Click += btnCompareTime_Click;
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        // Обработчики кнопок
        public void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateIntervals();
            lblCount.Visible = true;
        }

        public void btnRunBruteForce_Click(object sender, EventArgs e)
        {
            RunBruteForceMethod();
            lblBruteForceTime.Visible = true;
        }

        public void btnRunOptimized_Click(object sender, EventArgs e)
        {
            RunOptimizedMethod();
            lblOptimizedTime.Visible = true;
        }
        public void btnCompareTime_Click(object sender, EventArgs e)
        {
            // Проверка: есть ли данные?
            if (intervals.Count == 0)
            {
                MessageBox.Show("Сначала сгенерируйте интервалы!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка: запущены ли оба метода?
            if (lblBruteForceTime.Text == "" || lblOptimizedTime.Text == "")
            {
                MessageBox.Show("Сначала запустите оба метода!", "Внимание",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Извлекаем дробные числа из текста меток
            string bruteForceStr = lblBruteForceTime.Text.Replace("Время: ", "").Replace(" мс", "");
            string optimizedStr = lblOptimizedTime.Text.Replace("Время: ", "").Replace(" мс", "");

            if (double.TryParse(bruteForceStr, out double bruteForceTime) &&
                double.TryParse(optimizedStr, out double optimizedTime))
            {
                // Сравниваем и выводим результат
                if (bruteForceTime > optimizedTime)
                {
                    double diff = bruteForceTime - optimizedTime;
                    lblComparison.Text = $"Оптимизированный метод быстрее на {diff:F6} мс";
                }
                else if (optimizedTime > bruteForceTime)
                {
                    double diff = optimizedTime - bruteForceTime;
                    lblComparison.Text = $"Полный перебор быстрее на {diff:F6} мс";
                }
                else
                {
                    lblComparison.Text = "Время выполнения одинаково";
                }

                lblComparison.Visible = true;
            }
            else
            {
                MessageBox.Show("Ошибка при чтении времени выполнения", "Ошибка",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательные методы
        public void GenerateIntervals()
        {
            int count = random.Next(10, 1001);
            intervals.Clear();

            for (int i = 0; i < count; i++)
            {
                int start = random.Next(0, 1000000);
                int end = start + random.Next(100, 50000);
                intervals.Add(new Interval(start, end));
            }

            UpdateOriginalListBox();
            lblCount.Text = $"Количество интервалов: {count}";
            ClearResults();
        }
        public void RunBruteForceMethod()
        {
            if (intervals.Count == 0)
            {
                ShowWarning("Сначала сгенерируйте интервалы!");
                return;
            }

            var (result, preciseTime) = IntervalMerger.MergeBruteForce(intervals);

            lstBruteForce.Items.Clear();
            foreach (var interval in result)
            {
                lstBruteForce.Items.Add(interval.ToString());
            }

            lblBruteForceTime.Text = $"Время: {preciseTime:F6} мс";
        }

        public void RunOptimizedMethod()
        {
            if (intervals.Count == 0)
            {
                ShowWarning("Сначала сгенерируйте интервалы!");
                return;
            }

            var (result, preciseTime) = IntervalMerger.MergeOptimized(intervals);

            lstOptimized.Items.Clear();
            foreach (var interval in result)
            {
                lstOptimized.Items.Add(interval.ToString());
            }
            lblOptimizedTime.Text = $"Время: {preciseTime:F6} мс";
        }

        public void UpdateOriginalListBox()
        {
            lstOriginal.Items.Clear();
            foreach (var interval in intervals)
            {
                lstOriginal.Items.Add(interval.ToString());
            }
        } //обновление данных в листе со входными данными

        public void ClearResults()
        {
            lstBruteForce.Items.Clear();
            lstOptimized.Items.Clear();
            lblBruteForceTime.Text = "";
            lblOptimizedTime.Text = "";
        } //очистка листов с решениями сортировок

        public List<Interval> GetIntervalsFromListBox(ListBox listBox)
        {
            var intervals = new List<Interval>();
            foreach (string item in listBox.Items)
            {
                intervals.Add(Interval.Parse(item));
            }
            return intervals;
        }

        public void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void lstOptimized_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRunOptimized_Click_1(object sender, EventArgs e)
        {

        }

        private void lblComparison_Click(object sender, EventArgs e)
        {

        }
    }
}
