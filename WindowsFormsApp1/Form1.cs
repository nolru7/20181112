using System;
using System.Collections;
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
        private Label lb;


        private void Form1_Load(object sender, EventArgs e)
        {
            // 가상 데이터 생성
            ArrayList arrList = new ArrayList();
            arrList.Add(new Item("button", 30, 30, "btn_1"));
            arrList.Add(new Item("label", 30, 110, "lb_1"));
            arrList.Add(new Item("button", 30, 190, "btn_2"));

            // 가상 데이터를 이용한 화면 구성하기
            for (int i = 0; i < arrList.Count; i++)
            {
                Control_Create((Item)arrList[i]);
            }
            /*
            string[] ctrList = {"button","label","button"};

            for (int i = 0; i < ctrList.Length; i++)
            {
                if (ctrList[i] == "button")
                {
                    Controls.Add(btn_create(i));
                }
                else if (ctrList[i] == "label")
                {
                    Controls.Add(lb_create(i));
                }
            }
            */
        }
        private void Control_Create(Item item)
        {
            Control ctr = new Control();

            switch (item.getType())
            {
                case "button":
                    Button btn = new Button();
                    btn.DialogResult = DialogResult.OK;
                    btn.Cursor = Cursors.Hand;
                    btn.Click += btn_click;
                    ctr = btn;
                    break;
                case "label":
                    ctr = new Label();
                    break;
                default:
                    break;
            }
            ctr.Name = item.getTxt();
            ctr.Text = item.getTxt();
            ctr.Size = new Size(100, 50);
            ctr.Location = new Point(item.getX(), item.getY());
            Controls.Add(ctr);

        }

        private Button btn_create(int i) //버튼생성 메소드화
        {
            btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = string.Format("btn_{0}", (i + 1));
            btn.Text = string.Format("확인 : {0}", (i + 1));
            btn.Size = new Size(100, 50);
            btn.Location = new Point((100 * i) + 30, 30);
            btn.Cursor = Cursors.Hand;
            btn.Click += btn_click;
            return btn;
        }

        private Label lb_create(int i)
        {
            lb = new Label();
            btn.DialogResult = DialogResult.OK;
            btn.Name = string.Format("lb_{0}", (i + 1));
            btn.Text = string.Format("확인 :{0}", (i + 1));
            btn.Size = new Size(100, 50);
            btn.Location = new Point((100 * i) + 30, 30);

            return lb;
        }
        private void btn_click(object o, EventArgs a) //object는 버튼정보를 받아올수 있다.
        {
            //string names = "";
            foreach (Control ct in Controls)
            {
                //names += ct.Name + "";
                if (ct.Name != "btn_3") ct.BackColor = Color.Silver; //버튼하나만 색변경
            }

            //MessageBox.Show(names);

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


    public class Item
    {
        string type;
        int x;
        int y;
        string txt;

        public Item(string type, int x, int y, string txt)
        {
            this.type = type;
            this.x = x;
            this.y = y;
            this.txt = txt;

        }
        public string getType()
        {

            return type;
        }
        public int getX()
        {

            return x;
        }
        public int getY()
        {

            return y;
        }
        public string getTxt()
        {

            return txt;
        }
    }
}
