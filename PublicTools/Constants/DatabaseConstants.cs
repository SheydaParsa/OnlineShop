using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PublicTools.Constants.DatabaseConstants.CheckConstraints;

namespace PublicTools.Constants
{
    public static class DatabaseConstants
    {
        #region [Schemas]
        public static class Schemas
        {
            public const string Infrastructure = "Infrastructure";
            public const string UserManagement = "UserManagement";
            public const string Sale = "Sale";
        }
        #endregion

        #region [CheckConstraints]
        public static class CheckConstraints
        {
            public enum ReturnValueTypes
            {
                ScriptTitle = 1,
                ScriptCode = 2,

            }


          #region [SetOnlyNumericalCheckConstraint]
        public static string SetOnlyNumericalCheckConstraint(string propertyTitle, ReturnValueTypes returnValueTypes)
        {
            return returnValueTypes switch
            {
                (ReturnValueTypes)1 => $"Chech_{propertyTitle}_OnlyNumerical",
                (ReturnValueTypes)2 => $"Chech_{propertyTitle} Not Like'%[^0-9]%'",
                _ => string.Empty,
            };
        }
        #endregion

           #region [SetDigitsLimitCheckConstraint]
        public static string SetDigitsLimitCheckConstraint(string propertyTitle, int digitLimit, ReturnValueTypes returnValueTypes)
        {
            var script = new StringBuilder();
            while (digitLimit != 0)
            {
                script.Append("[0-9]");
                digitLimit -= digitLimit;
            }
            return returnValueTypes switch
            {
                (ReturnValueTypes)1 => $"Check_{propertyTitle}_DigitsLimit",
                (ReturnValueTypes)2 => $"{propertyTitle}  LIKE '{script}' ",
                _ => string.Empty,
            };
        }
        #endregion

        }
        #endregion

        #region [DefaultRoles]
        public static class DefaultRoles
        {
            public const string GodAdminId = "1";
            public const string GodAdminName = "GodAdmin";
            public const string GodAdminNormalizedName = "GODADMIN";
            public const string GodAdminConcurrencyStamp = "1";


            public const string AdminId = "2";
            public const string AdminName = "Admin";
            public const string AdminNormalizedName = "ADMIN";
            public const string AdminConcurrencyStamp = "2";


            public const string SupportId = "3";
            public const string SupporName = "Suppor";
            public const string SupporNormalizedName = "SUPPORT";
            public const string SupporConcurrencyStamp = "3";

        }
        #endregion

        #region [GodAdminUsers]
        public static class GodAdminUsers
        {
            public const string SheydaUserId = "1";
            public const string SheydaFirstName = "Sheyda";
            public const string SheydaLasttName = "parsa";
            public const string SheydaPassword = "Sheyda@2001";
            public const string SheydaCellphone = "09374304381";

        } 
        #endregion
    }
}
