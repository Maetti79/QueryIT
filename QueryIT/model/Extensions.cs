using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

 public static class Extensions
    {

        public static T[] AddItemToArray<T>(this T[] original, T itemToAdd)
        {
            if (original != null) {
                T[] finalArray = new T[original.Length + 1];
                for (int i = 0; i < original.Length; i++)
                {
                    finalArray[i] = original[i];
                }
                finalArray[finalArray.Length - 1] = itemToAdd;
                return finalArray;
            } else {
                T[] finalArray = new T[1];
                finalArray[finalArray.Length - 1] = itemToAdd;
                return finalArray;
            }
        }


        public static T[] Clear<T>(this T[] original) {
                T[] finalArray = new T[0];
                return finalArray;
        }

        public static T[] RemoveAt<T>(this T[] original, int index)
        {
            if (original != null)
            {
                T[] finalArray = new T[original.Length - 1];
                int added = 0;
                for (int i = 0; i < original.Length; i++)
                {
                    if (i != index)
                    {
                        finalArray[added] = original[i];
                        added++;
                    }
                }
                return finalArray;
            } else {
                T[] finalArray = new T[0];
                return finalArray;
            }
        }

        public static string checksum<T>(this T[] original)
        {
            string concat = "";
           
            if (original != null)
            {
                for (int i = 0; i < original.Length; i++)
                {
                     concat += original[i].ToString();
                }
                MD5 md5Hash = MD5.Create();
                return GetMd5Hash(md5Hash, concat);
            }
            else
            {
                return null;
            }
        }

        public static bool arrEquals<T>(this T[] original, T[] comparison) {
            bool equals = true;
            if(original != null && comparison != null) {
                if(original.Length != comparison.Length) {
                    equals = false;
                } else {
                    for(int i = 0; i < original.Length; i++) {
                        if(original[i].ToString() != comparison[i].ToString()) {
                            equals = false;
                            break;
                        }
                    }
                }
            } else {
                equals = false;
            }
            return equals;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }

