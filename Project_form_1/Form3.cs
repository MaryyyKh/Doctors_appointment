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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // экземпляр класс Patient, в него ведется запись данных о пользователе
        Patient man = new Patient();
        
        // конструктор класса Form3("Вход в приложение"),
        // принимающий данные о пользователе из Form2("Пароль и полис ОМС")
        public Form3(Patient man_)
        {
            InitializeComponent();
            man = man_;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // выбор способа входа: по электронной почте или по номеру телефона
            if (radioButton1.Checked)
                label3.Text = radioButton1.Text;
            else
                label3.Text = radioButton2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(man.PinCode);
            if (label3.Text == "Почта")
            {
                // проверка корректности связки данных "Электронная почта - пароль", введенных пользователем
                if (mail_Text.Text != man.Mail || maskedTextBox1.Text != man.PinCode)
                    MessageBox.Show("Неправильно введены данные для входа." + "\n" + "Повторите попытку.");
                else
                {
                    // связь формы "Вход в приложение" с формой "Запись ко врачу"
                    // передача информации о пользователе в форму "Запись ко врачу"
                    Form4 newForm = new Form4(man);
                    newForm.Show();
                }
            }
            else
            {
                // проверка корректности связки данных "Номер телефона - пароль", введенных пользователем
                if (mail_Text.Text != man.Phone || maskedTextBox1.Text != man.PinCode)
                    MessageBox.Show("Неправильно введены данные для входа." + "\n" + "Повторите попытку.");
                else
                {
                    // связь формы "Вход в приложение" с формой "Запись ко врачу"
                    // передача информации о пользователе в форму "Запись ко врачу"
                    Form4 newForm = new Form4(man);
                    newForm.Show();
                }
            }
                


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // выбор способа входа: по электронной почте или по номеру телефона
            if (radioButton2.Checked)
                label3.Text = radioButton2.Text;
            else
                label3.Text = radioButton1.Text;
        }
    }
}