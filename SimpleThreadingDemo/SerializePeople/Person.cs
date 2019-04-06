using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    class Person
    {
        private string _name;
        private DateTime _birthDate;
        private Gender _gender;
        private int _age;

        public string Name { get => _name; set => _name = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        private Gender HumanGender { get => _gender; set => _gender = value; }
        public int Age { get => _age; set => _age = value; }

        public enum Gender { Male, Female }

        public Person(string name, DateTime birthDate, Gender humanGender)
        {
            Name = name;
            BirthDate = birthDate;
            HumanGender = humanGender;

            DateTime today = DateTime.Today;
            try
            {
                TimeSpan difference = today.Subtract(birthDate);
                this.Age = difference.Days / 365;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ToString());
            }

            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ToString());
            }
        }

        public void Serialize(string output)
        {

            if (File.Exists(output))
            {
                File.Delete(output);
            }

            FileStream fileStream = new FileStream(output, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fileStream, this);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public override string ToString()
        {
            return "Name of the person is: " + Name + " born on the " + BirthDate.ToString();
        }
    }
}
