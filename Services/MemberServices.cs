using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumCafe.Components.Pages;
using BisleriumCafe.Models;
using Microsoft.AspNetCore.Components;

namespace BisleriumCafe.Services {

    public class MemberServices : JsonServices<Members>
    {



        public static String memberDirectoryPath = Utility.GetMemberDirectoryPath();

        public  List<Members> CreateMember(GlobalState globalState, string name, string phoneNumber, DateTime expirydate)
        {
            name =name.Trim();
            phoneNumber = phoneNumber.Trim();
            DateTime abc = expirydate;

            if (name == "" || phoneNumber == "")
            {
                throw new Exception("Please Enter Valid Details");
            }

            var members = GetAllData(memberDirectoryPath);

            var memberExists = members.Any(x => x.PhoneNumber == phoneNumber);

            if (memberExists)
            {
                throw new Exception("Sorry, Member Already Exsist.");
            }

            var user = new Members()
            {
                Username = name,
                PhoneNumber = phoneNumber,
                ExpiryDate = expirydate,
                CreatedBy = globalState.CurrentUser.Username,
            };

            members.Add(user);

            SaveData(members, memberDirectoryPath);

            return members;

        }

        public List<Members> Update(Guid id, string name, string phoneNumber, DateTime newExpiryDate)
        {


            var members = GetAllData(memberDirectoryPath);

            var member = members.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                throw new Exception("Members not found.");
            }

            member.Username = name;
            member.PhoneNumber = phoneNumber;
            member.ExpiryDate = newExpiryDate;

            SaveData(members, memberDirectoryPath);

            return members;
        }

        public  List<Members> Delete(Guid id)
        {
            var members = GetAllData(memberDirectoryPath);

            var member = members.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                throw new Exception("Addins not found.");
            }

            members.Remove(member);

            SaveData(members, memberDirectoryPath);

            return members;
        }
    }
}