using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ServerController
{
    public class CtrGetData
    {
        public ArrayList GetUserData(string email)
        {
            ServerModel.MdlStudent mdlStudentObj = new ServerModel.MdlStudent(email, null);
            ServerModel.MdlLandlord mdlLandlordObj = new ServerModel.MdlLandlord(email, null);

            if (GetUserType(email).Equals("student"))
            {
                Console.WriteLine("User is of type: Student.");
                mdlStudentObj = ServerDatabase.DbGetData.GetStudentData(mdlStudentObj);
                return FillArrayListStudent(mdlStudentObj);
            }
            else if (GetUserType(email).Equals("landlord"))
            {
                Console.WriteLine("User is of type: Landlord.");
                mdlLandlordObj = ServerDatabase.DbGetData.GetLandlordData(mdlLandlordObj);
                return FillArrayListLandlord(mdlLandlordObj);
            }
            else
            {
                ArrayList array = new ArrayList();
                Console.WriteLine("Unable to get Users information.");
                return array;
            }

        }

        private string GetUserType(string email)
        {
            return ServerDatabase.DbGetData.GetUserType(email);
        }

        private ArrayList FillArrayListStudent(ServerModel.MdlStudent mdlStudentObj)
        {
            ArrayList userData = new ArrayList();

            userData.Add(mdlStudentObj.Id); //0
            userData.Add(mdlStudentObj.Email); //1
            //leave password null
            userData.Add(""); //2
            userData.Add(mdlStudentObj.Confirmed);//3
            userData.Add(mdlStudentObj.Student);//4
            userData.Add(mdlStudentObj.Score);//5
            userData.Add(mdlStudentObj.NumberOfChildren);//6
            userData.Add(mdlStudentObj.Pet);//7
            userData.Add(mdlStudentObj.NumberOfCohabiters);//8
            userData.Add(mdlStudentObj.Disabled);//9
            userData.Add(mdlStudentObj.DateOfCreation);//10
            userData.Add(mdlStudentObj.Name);//11
            userData.Add(mdlStudentObj.Surname);//12
            userData.Add(mdlStudentObj.Address);//13
            userData.Add(mdlStudentObj.PostCode);//14
            userData.Add(mdlStudentObj.City);//15
            userData.Add(mdlStudentObj.Country);//16
            userData.Add(mdlStudentObj.Phone);//17
            userData.Add("student");//18

            Console.WriteLine("Returning populated arraylist to the client.");
            return userData;
        }

        private ArrayList FillArrayListLandlord(ServerModel.MdlLandlord mdlLandlordObj)
        {
            ArrayList userData = new ArrayList();

            userData.Add(mdlLandlordObj.Id); //0
            userData.Add(mdlLandlordObj.Email); //1
            //leave password null
            userData.Add(""); //2
            userData.Add(mdlLandlordObj.Confirmed);//3
            userData.Add(null);//4
            userData.Add(null);//5
            userData.Add(null);//6
            userData.Add(null);//7
            userData.Add(null);//8
            userData.Add(null);//9
            userData.Add(mdlLandlordObj.DateOfCreation);//10
            userData.Add(mdlLandlordObj.Name);//11
            userData.Add(mdlLandlordObj.Surname);//12
            userData.Add(mdlLandlordObj.Address);//13
            userData.Add(mdlLandlordObj.PostCode);//14
            userData.Add(mdlLandlordObj.City);//15
            userData.Add(mdlLandlordObj.Country);//16
            userData.Add(mdlLandlordObj.Phone);//17
            userData.Add("landlord");//18

            Console.WriteLine("Returning populated arraylist to the client.");
            return userData;
        }
    }
}
