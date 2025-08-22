using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Persistence.Helper
{
    public static class UserHelper
    {
        public static string GetFormattedName(UserProfile? user) =>
            user != null
                ? $"{user.FirstName} {user.LastName}".Trim()
                : string.Empty;

        public static string GetFullName(string title, string firstName, string middleName, string lastName)
        {
            return string.Join(" ",
                new[] { title, firstName, middleName, lastName }
                .Where(s => !string.IsNullOrWhiteSpace(s)));
        }

        public static string GetFullAddress(string address1, string address, string pinCode, string district, string stateName, string country)
        {
            return string.Join(" ",
                new[] { address1, address, pinCode, district, stateName, country }
                .Where(s => !string.IsNullOrWhiteSpace(s)));
        }
        public static string GetIdCardAddress(
            string address1,
            string address2,
            string pinCode,
            int maxLength = 30)
        {
            // Normalize inputs
            address1 = address1?.Trim() ?? "";
            address2 = address2?.Trim() ?? "";
            pinCode = (pinCode ?? string.Empty).Trim();
            pinCode = pinCode.Length >= 6 ? pinCode.Substring(0, 6) : pinCode.PadLeft(6);

            // Combine address parts
            var parts = new[] { address1, address2 }
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(ToTitleCase); // ← Capitalize

            var fullAddress = string.Join(" ", parts);

            // Reserve space: 1 space + 6 digit pin
            int allowedForAddress = maxLength - 1 - pinCode.Length;
            if (allowedForAddress < 0) allowedForAddress = 0;

            // Trim if needed
            if (fullAddress.Length > allowedForAddress)
                fullAddress = fullAddress.Substring(0, allowedForAddress).TrimEnd();

            return string.IsNullOrEmpty(fullAddress)
                ? pinCode
                : $"{fullAddress} {pinCode}";
        }


        private static string ToTitleCase(string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(input.ToLower());
        }

        public static string GetIdCardName(
         string title,
         string firstName,
         string middleName,
         string lastName,
         int maxNameLength = 30)
        {
            // Normalize inputs
            title = title?.Trim() ?? "";
            firstName = firstName?.Trim() ?? "";
            middleName = middleName?.Trim() ?? "";
            lastName = lastName?.Trim() ?? "";

            // Build the “full” portion (excluding title and spaces)
            var fullNameOnly = string.Join(" ",
                new[] { firstName, middleName, lastName }
                .Where(s => !string.IsNullOrWhiteSpace(s)));

            // If it already fits, just return Title + full name
            if (fullNameOnly.Length <= maxNameLength)
            {
                return string.Join(" ",
                    new[] { title, fullNameOnly }
                    .Where(s => !string.IsNullOrWhiteSpace(s)));
            }

            // Otherwise, switch to initials for first and middle
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(title))
                parts.Add(title);

            // First name initial
            if (!string.IsNullOrWhiteSpace(firstName))
                parts.Add(firstName[0] + ".");

            // Middle name initial
            if (!string.IsNullOrWhiteSpace(middleName))
                parts.Add(middleName[0] + ".");

            // Always include the full last name
            if (!string.IsNullOrWhiteSpace(lastName))
                parts.Add(lastName);

            return string.Join(" ", parts);
        }
    }
}
