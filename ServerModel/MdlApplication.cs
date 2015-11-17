using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ServerModel
{
    [DataContract]
    public class MdlApplication
    {
        private int _id;
        private int _studentId;
        private int _flatId;
        private DateTime _dateOfCreation;
        private int _score;
        private int _queueNumber;

        public MdlApplication(int id, int studentId, int flatId, DateTime dateOfCreation, int score, int queueNumber)
        {
            _id = id;
            _studentId = studentId;
            _flatId = flatId;
            _dateOfCreation = dateOfCreation;
            _score = score;
            _queueNumber = queueNumber;
        }

        public MdlApplication()
        {

        }

        [DataMember(Name = "ID", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Name = "Student_ID", Order = 2)]
        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        [DataMember(Name = "Flat_ID", Order = 3)]
        public int FlatId
        {
            get { return _flatId; }
            set { _flatId = value; }
        }

        [DataMember(Name = "Date_Of_Creation", Order = 4)]
        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
            set { _dateOfCreation = value; }
        }

        [DataMember(Order = 5)]
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        [DataMember(Order = 6)]
        public int QueueNumber
        {
            get { return _queueNumber; }
            set { _queueNumber = value; }
        }
    }
}
