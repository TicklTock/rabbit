using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace rabbit
{

    public partial class Form1 : Form
    {
        //�����¼����������
        Point startPoint = new Point();
        //�����¼��갴��ʱ��
        DateTime downTime;
        //�����¼��굯��ʱ��
        DateTime upTime;

        public Form1()
        {
            InitializeComponent();
        }


        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            //��¼��ǰ������꼰�Ƿ���״̬
            if (e.Button == MouseButtons.Left)
            {
                //��¼��ʼλ��
                startPoint = e.Location;
                //������갴��ʱ��
                downTime = DateTime.Now;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            
            //����ƶ� �޸Ĵ�������
            if (e.Button == MouseButtons.Left)
            {
                this.Location = this.PointToScreen(new Point(e.X - startPoint.X, e.Y - startPoint.Y));
            }
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setRabbitStay()
        {
            label1.Image = Properties.Resources.stay;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //������굯��󴥷�����¼���ʱ��
            upTime = DateTime.Now;
            //������갴�µ������ʱ��
            TimeSpan interval = this.upTime - this.downTime;
            //������ʱ��>200ms����Ϊ�ƶ�����
            if (interval.Milliseconds > 200) {
                return;
            }
            label1.Image = Properties.Resources.move;
            //�趨�̶��ӳ٣���֤gif�����л���������
            Task.Delay
                (4500).ContinueWith(t =>
                {
                    setRabbitStay();
                });
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ͬʱ�������Դ���ShowInTaskbar=false and TopMost = true�����Ҵ˴�ΪTopMost = true�����ܳɹ��ö���
            TopMost = true;
        }
    }
}