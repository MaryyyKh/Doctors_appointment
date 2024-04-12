using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_Library;

namespace Project_form_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // экземпляр класс Patient, в него ведется запись данных о пользователе
        Patient man = new Patient();
        // конструктор класса Form2("Пароль и полис ОМС"),
        // принимающий данные о пользователе из Form1("Окно регистрации")
        public Form2(Patient man_)
        {
            InitializeComponent();

            man = man_;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // обработка вводимого пароля. При несовпадении первого пароля со вторым,
            // выводится сообщение на экран, иначе пароль закрепляется за пользователем
            if (maskedTextBox1.Text != maskedTextBox2.Text)
                MessageBox.Show("Введенные пароли не совпадают. Повторите попытку.");
            else
            {
                man.PinCode = maskedTextBox1.Text;
                MessageBox.Show("Пароль успешно записан!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // запись полиса ОМС пользователя в ячейку MedPolyce объекта man
            man.MedPolyce = maskedTextBox3.Text;

            // вывод сообщения на экран
            label10.Text = "Спасибо за регистрацию!";

            // связь формы "Пароль и полис ОМС" с формой "Вход в приложение"
            // передача информации о пользователе в форму "Вход в приложение"
            Form3 newForm = new Form3(man);
            newForm.Show();
        }
    }
}