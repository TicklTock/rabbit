using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace rabbit
{

    public partial class Form1 : Form
    {
        //定义记录鼠标坐标变量
        Point startPoint = new Point();
        //定义记录鼠标按下时间
        DateTime downTime;
        //定义记录鼠标弹起时间
        DateTime upTime;

        public Form1()
        {
            InitializeComponent();
        }


        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            //记录当前点击坐标及是否按下状态
            if (e.Button == MouseButtons.Left)
            {
                //记录起始位置
                startPoint = e.Location;
                //计算鼠标按下时间
                downTime = DateTime.Now;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            
            //左键移动 修改窗体坐标
            if (e.Button == MouseButtons.Left)
            {
                this.Location = this.PointToScreen(new Point(e.X - startPoint.X, e.Y - startPoint.Y));
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setRabbitStay()
        {
            label1.Image = Properties.Resources.stay;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //计算鼠标弹起后触发点击事件的时间
            upTime = DateTime.Now;
            //计算鼠标按下到弹起的时间
            TimeSpan interval = this.upTime - this.downTime;
            //如果间隔时间>200ms则视为移动操作
            if (interval.Milliseconds > 200) {
                return;
            }
            label1.Image = Properties.Resources.move;
            //设定固定延迟，保证gif动画切换的流畅性
            Task.Delay
                (4500).ContinueWith(t =>
                {
                    setRabbitStay();
                });
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //同时满足属性窗口ShowInTaskbar=false and TopMost = true，并且此处为TopMost = true，才能成功置顶。
            TopMost = true;
        }
    }
}