using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;


        }

        private Button btn;

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                btn = new Button();

                btn.DialogResult = DialogResult.OK;
                btn.Text = string.Format("확인 :{0}", (i + 1));
                btn.Size = new Size(100, 50);
                btn.Location = new Point((100 * i) + 30, 30);

                btn.Cursor = Cursors.Hand;//마우스 커서 손가락표시로 변경

                Controls.Add(btn);
                btn.Click += btn_click;
            }

        }


        private void btn_click(object o, EventArgs a) //object는 버튼정보를 받아올수 있다.
        {
            btn = (Button)o; //button으로 형변환
            //MessageBox.Show(btn.Text);
            btn.BackColor = (btn.BackColor == Color.Green) ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green;
            // 삼항연산자로 변경
            //if (btn.BackColor == Color.Green)
            //{
            //    btn.BackColor = Color.Silver; //클릭시 버튼색 변경
            //}
            //else
            //{
            //    btn.BackColor = Color.Green;
            //}
        }

    }
}
