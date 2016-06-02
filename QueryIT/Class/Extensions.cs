using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using QueryIT.model;

public static class Extensions {

    public static T[] AddItemToArray<T>(this T[] original, T itemToAdd) {
        if(original != null) {
            T[] finalArray = new T[original.Length + 1];
            for(int i = 0; i < original.Length; i++) {
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

    public static T[] RemoveAt<T>(this T[] original, int index) {
        if(original != null) {
            T[] finalArray = new T[original.Length - 1];
            int added = 0;
            for(int i = 0; i < original.Length; i++) {
                if(i != index) {
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

    public static T[] Update<T>(this T[] original, T itemToAdd) {
            if(original != null) {
                T[] finalArray = new T[original.Length];
                for(int i = 0; i < original.Length; i++) {
                    if(original[i].Equals(itemToAdd) == true) {
                        finalArray[i] = itemToAdd;
                    } else {
                        finalArray[i] = original[i];
                    }
                }
                return finalArray;
            } else {
                T[] finalArray = new T[0];
                return finalArray;
            }
    }

    public static string checksum<T>(this T[] original) {
        string concat = "";

        if(original != null) {
            for(int i = 0; i < original.Length; i++) {
                concat += original[i].ToString();
            }
            MD5 md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, concat);
        } else {
            return null;
        }
    }

    public static string checksum<T>(this T original) {

        if(original != null) {
            MD5 md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, original.ToString());
        } else {
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

    public static string GetMd5Hash(MD5 md5Hash, string input) {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for(int i = 0; i < data.Length; i++) {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    public static string[] ItemArray(this DataGridViewRow r) {
        string[] items = null;
        foreach(DataGridViewCell c in r.Cells) {
            items = items.AddItemToArray(c.Value.ToString());
        }
        return items;
    }

    public static void SyntaxHighlight(this RichTextBox inrtf) {
        RichTextBox rtf = new RichTextBox();
        int selectStartmem = inrtf.SelectionStart;
        rtf.Rtf = inrtf.Rtf;
        rtf.Select(0, rtf.Text.Length);
        rtf.SelectionFont = rtf.Font;
        rtf.SelectionColor = Color.Black;
        //BlueBold
        foreach(string k in SQLSyntax.SQLblue) {
            if(rtf.Text.ToLower().Contains(k)) {
                int index = -1;
                int selectStart = rtf.SelectionStart;
                while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                    if(index + k.Length + 1 <= rtf.Text.Length) {
                        rtf.Select(index, k.Length + 1);
                    } else {
                        rtf.Select(index, k.Length);
                    }
                    if(rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "(")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "[")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + ",")
                        || rtf.Text.ToLower().StartsWith(k.ToString().ToLower() + " ")
                        || rtf.Text.ToLower().EndsWith(k.ToString().ToLower()+ " ")
                        || rtf.Text.ToLower().EndsWith(k.ToString().ToLower()+ ";")
                        ) {
                        rtf.Select((index), k.Length);
                        rtf.SelectionColor = Color.Blue;
                        rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                        rtf.SelectedText = rtf.SelectedText.ToUpper();
                        rtf.Select(selectStart, 0);
                        rtf.SelectionFont = rtf.Font;
                        rtf.SelectionColor = Color.Black;
                    }
                }
            }
        }
        //MagentaBold
        foreach(string k in SQLSyntax.SQLmagenta) {
            if(rtf.Text.ToLower().Contains(k)) {
                int index = -1;
                int selectStart = rtf.SelectionStart;
                while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                    if(index + k.Length + 1 <= rtf.Text.Length) {
                        rtf.Select(index, k.Length + 1);
                    } else {
                        rtf.Select(index, k.Length);
                    }
                    if(rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "(")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + ")")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "[")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "]")
                        || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + ",")
                        || rtf.Text.ToLower().StartsWith(k.ToString().ToLower() + " ")
                        || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + " ")
                        || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + ";")
                        ) {
                        rtf.Select((index), k.Length);
                        rtf.SelectionColor = Color.Magenta;
                        rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                        rtf.Select(selectStart, 0);
                        rtf.SelectionFont = rtf.Font;
                        rtf.SelectionColor = Color.Black;
                    }
                }
            }
        }
        //redBold
        foreach(string k in SQLSyntax.SQLred) {
            if(rtf.Text.ToLower().Contains(k)) {
                int index = -1;
                int selectStart = rtf.SelectionStart;
                while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                    rtf.Select(index, k.Length);
                    if(rtf.SelectedText.ToLower().Equals(k.ToString().ToLower())) {
                        rtf.Select((index), k.Length);
                        rtf.SelectionColor = Color.Red;
                        rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                        rtf.Select(selectStart, 0);
                        rtf.SelectionFont = rtf.Font;
                        rtf.SelectionColor = Color.Black;
                    }
                }
            }
        }
        //greenBold
        foreach(string k in SQLSyntax.SQLgreen) {
            if(rtf.Text.ToLower().Contains(k)) {
                int index = -1;
                int selectStart = rtf.SelectionStart;
                while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                    rtf.Select(index, k.Length);
                    if(rtf.SelectedText.ToLower().Equals(k.ToString().ToLower())) {
                        rtf.Select((index), k.Length);
                        rtf.SelectionColor = Color.DarkGreen;
                        rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                        rtf.Select(selectStart, 0);
                        rtf.SelectionFont = rtf.Font;
                        rtf.SelectionColor = Color.Black;
                    }
                }
            }
        }
        //grayBold
        foreach(string k in SQLSyntax.SQlgray) {
            if(rtf.Text.ToLower().Contains(k)) {
                int index = -1;
                int selectStart = rtf.SelectionStart;
                while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                    rtf.Select(index, k.Length);
                    if(rtf.SelectedText.ToLower().Equals(k.ToString().ToLower())) {
                        rtf.Select((index), k.Length);
                        rtf.SelectionColor = Color.Black;
                        rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                        rtf.Select(selectStart, 0);
                        rtf.SelectionFont = rtf.Font;
                        rtf.SelectionColor = Color.Black;
                    }
                }
            }
        }

        string c = "";
        int sindex = -1;
        int sselectStart = rtf.SelectionStart;
        for(int i = 0; i < rtf.Text.Length; i++) {
            c = rtf.Text.Substring(i, 1).ToString();
            if(c == "'") {
                if(sindex == -1) {
                    sindex = i;
                } else {
                    rtf.Select((sindex) + 1, i - sindex - 1);
                    rtf.SelectionColor = Color.DarkGreen;
                    rtf.SelectionFont = new Font(rtf.Font, FontStyle.Italic);
                    rtf.Select(sselectStart, 0);
                    rtf.SelectionFont = rtf.Font;
                    rtf.SelectionColor = Color.Black;
                    sindex = -1;
                }
            }
        }

        c = "";
        sindex = -1;
        sselectStart = rtf.SelectionStart;
        for(int i = 0; i < rtf.Text.Length; i++) {
            c = rtf.Text.Substring(i, 1).ToString();
            if(c == "#") {
                if(sindex == -1) {
                    sindex = i;
                } else {
                    rtf.Select((sindex) + 1, i - sindex - 1);
                    rtf.SelectionColor = Color.DarkViolet;
                    rtf.SelectionFont = new Font(rtf.Font, FontStyle.Italic);
                    rtf.Select(sselectStart, 0);
                    rtf.SelectionFont = rtf.Font;
                    rtf.SelectionColor = Color.Black;
                    sindex = -1;
                }
            }
        }

        inrtf.Rtf = rtf.Rtf;
        inrtf.Select(selectStartmem, 0);
    }

}

