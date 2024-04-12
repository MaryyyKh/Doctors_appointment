using System;
using System.Globalization;
using System.Windows.Forms;


namespace Class_Library
{
    public class Person
    {
        public string[] data = new string[100];
        public struct fullName
        {
            public string name, surname, patronymic;

            // вывод в формате "Имя Отчество Фамилия"
            public string PrintAll()
            {
                return name + " " + patronymic + " " + surname;
            }

            // вывод в формате "И. О. Фамилия"
            public string PrintInit()
            {
                return name[0] + ". " + patronymic[0] + ". " + surname;
            }
        }
        private string mail_;
        private fullName nameOfPerson_;

        public string Name { 
            get { return nameOfPerson_.name; } 
            set { nameOfPerson_.name = value; } 
        }
        public string Surname { 
            get { return nameOfPerson_.surname; } 
            set { nameOfPerson_.surname = value; } 
        }
        public string Patronymic { 
            get { return nameOfPerson_.patronymic; } 
            set { nameOfPerson_.patronymic = value; } 
        }
        public fullName NameOfPerson {
            get { return nameOfPerson_; } 
            set { nameOfPerson_ = value; } 
        }
        public virtual string Mail { 
            set {
                if (!value.Contains("@"))
                    MessageBox.Show("Почта указана неверно, она должна содержать знак @.");
                else
                    mail_ = value;
            } 
            get { return mail_; } 
        }

        public Person() { }
        public Person(string name_, string surname_, string patronymic_, string name, string surname, string patronymic)
        {
            this.nameOfPerson_.name = name_;
            this.nameOfPerson_.surname = surname_;
            this.nameOfPerson_.patronymic = patronymic_;
        }

        // вывод в формате "Имя Фамилия Отчество"
        public string PrintInformation() {
            return Name + " " + Surname + " " + Patronymic;
        }
    }

    public class Patient : Person
    {
        public struct date
        {
            public string day, month, year;
            
            // вывод в формате "ДД.ММ.ГГГГ"
            public string Information()
            {
                return day + "." + month + "." + year;
            }
        }
        private string gender_, phone_, medPolyce_, pinCode_;
        private date dateOfBirth_;
        
        public string Gender { get { return gender_; } set { gender_ = value; } }
        public string Phone { get { return phone_; } set { phone_ = value; } }
        public string MedPolyce { get { return medPolyce_; } set { medPolyce_ = value; } }
        public string PinCode { get { return pinCode_; } set { pinCode_ = value; } }
        public string BDay { 
            get { return dateOfBirth_.day; } 
            set { dateOfBirth_.day = value; } 
        }
        public string BMonth { 
            get { return dateOfBirth_.month; } 
            set { dateOfBirth_.month = value; } 
        }
        public string BYear { 
            get { return dateOfBirth_.year; } 
            set { dateOfBirth_.year = value; } 
        }

        public Patient() { }
        public Patient(string name, string surname, string patronymic, string mail, string phone, string gender)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;

            Mail = mail;
            this.phone_ = phone;
            
            this.gender_ = gender;
        }

        // взятие дня, месяца и года из даты, введенной в формате "ДД.ММ.ГГГГ"
        public void GetDate(string date)
        {
            dateOfBirth_.day = date.Split('.')[0];
            dateOfBirth_.month = date.Split('.')[1];
            dateOfBirth_.year = date.Split('.')[2];
        }
        
        // установка пароля к аккаунту пользователя
        public void SetPinCode(string pinCode)
        {
            this.pinCode_ = pinCode;
        }
        
        // проверка правильности передаваемого пинкода
        public bool CheckPinCode(string pin_to_check)
        {
            return pin_to_check == PinCode ? true : false;
        }

        // вывод информации в формате "Ваши данные: Имя Отчество Фамилия ГГГГ г. р. пол <пол>"
        public string Print_inf()
        {
            return "Ваши данные: " + Name + " " + Patronymic + " " + Surname + " " +
                   BYear + " г.р. пол " + Gender;
        }
    }
    public class Doctor : Person
    {

        private int workExperience_;
        private string mail_, receptionTime_;


        public int WorkExperience { 
            get { return workExperience_; } 
            set { workExperience_ = value; } 
        }
        public override string Mail
        {
            set
            {
                if (value.Substring(value.Length - 9) != "@med.info")
                    MessageBox.Show("Почта указана неверно. В качестве логина " +
                        "используйте свою рабочую почту (домен @med.info)");
                else
                    mail_ = value;
            }
            get { return mail_; }
        }
        public string ReceptionTime { 
            get { return receptionTime_; } 
            set { receptionTime_ = value; }
        }

        public Doctor() { }
        public Doctor(string name, string surname, string patronymic, int workExperience, string mail)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;

            this.workExperience_ = workExperience;

            this.mail_ = mail;
        }

        // взятие времени начала и окончания приема из данных формата "ЧЧ:ММ-ЧЧ:ММ"
        public int[] GetReceptionTime()
        {
            int startTime = Convert.ToInt32(ReceptionTime.Split(':')[0]);
            int endTime = Convert.ToInt32(ReceptionTime.Split('-')[1].Split(':')[0]);
            int[] res = { startTime, endTime };
            return res;
        }

        // вывод данных в формате
        // "Сведения о докторе Имя Отчество Фамилия:"
        // "Почта: <почта>"
        // "Стаж работы: <количество> лет"
        new public string PrintInformation()
        {
            return "Сведения о докторе " + Name + " " + Patronymic + " " + Surname + ":" +
                   "\n" + "Почта: " + mail_ +
                   "\n" + "Стаж работы: " + workExperience_ + " лет";
        }
    }

    public class Appointment: Patient
    {
        private string time_;
        private date receptionDate_;
        private fullName doc_;

        public string Time { get { return time_; } set { time_ = value; } }
        public string Day
        {
            get { return receptionDate_.day; }
            set { receptionDate_.day = value; }
        }
        public string Month
        {
            get { return receptionDate_.month; }
            set { receptionDate_.month = value; }
        }
        public string Year
        {
            get { return receptionDate_.year; }
            set { receptionDate_.year = value; }
        }
        
        public fullName Doc
        {
            get { return doc_; }
            set { doc_ = value; }
        }
        public string DocN
        {
            get { return doc_.name; }
            set { doc_.name = value; }
        }
        public string DocS
        {
            get { return doc_.surname; }
            set { doc_.surname = value; }
        }
        public string DocP
        {
            get { return doc_.patronymic; }
            set { doc_.patronymic = value; }
        }

        public Appointment() { }
        public Appointment(Patient patient)
        {
            this.Name = patient.Name;
            this.Surname = patient.Surname;
            this.Patronymic = patient.Patronymic;
        }
        public Appointment(Patient patient, string datePatient, string time, Doctor doc)
        {
            this.Name = patient.Name;
            this.Surname = patient.Surname;
            this.Patronymic = patient.Patronymic;

            this.Day = datePatient.Split('.')[0];
            this.Month = datePatient.Split('.')[1];
            this.Year = datePatient.Split('.')[2];
            this.time_ = time;

            this.doc_.name = doc.Name;
            this.doc_.surname = doc.Surname;
            this.doc_.patronymic = doc.Patronymic;
        }
        
        // возврат даты в формате "ДД.ММ.ГГГГ"
        public string DateInf()
        {
            return Day + "." + Month + "." + Year;
        }

        // вывод данных в формате
        // "Дата записи: ДД.ММ.ГГГГ, время: ЧЧ:ММ"
        // "Специалист: И. О. Фамилия"
        new public string PrintInformation()
        {
            return "Дата записи: " + DateInf() + 
                ", время: " + time_ + "\n" + "Специалист: " + doc_.PrintInit();
        }
    }
}