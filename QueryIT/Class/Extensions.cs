using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using QueryIT.model;

public static class Extensions {

    public static bool lockSyntaxHighlighter = false;

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

    public static bool Contains<T>(this T[] original, string key) {
        bool contains = false;
        if(original != null) {
            for(int i = 0; i < original.Length; i++) {
                if(original[i].ToString() == key) {
                    contains = true;
                    break;
                }
            }
        }
        return contains;
    }

    public static T[] RemoveIfExists<T>(this T[] original, string key) {
        if(original != null) {
            T[] finalArray = new T[original.Length - 1];
            int added = 0;
            for(int i = 0; i < original.Length; i++) {
                if(original[i].ToString() != key) {
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
    /*
    public static void SyntaxHighlight2(this RichTextBox inrtf) {
        if(lockSyntaxHighlighter == false) {
            lockSyntaxHighlighter = true;
            RichTextBox rtf = new RichTextBox();
            if(inrtf.Text != null) {
                int selectStartmem = inrtf.SelectionStart;
                //rtf.Rtf = inrtf.Rtf;
                rtf.Text = SQLSyntax.fixSQL(inrtf.Text);
                rtf.Select(0, rtf.Text.Length);
                rtf.SelectionFont = rtf.Font;
                rtf.SelectionColor = Color.Black;
                //BlueBold
                foreach(string k in SQLSyntax.SQLblue) {
                    if(rtf.Text.ToLower().Contains(k)) {
                        int index = -1;
                        int selectStart = rtf.SelectionStart;
                        while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                            if(index > 0) {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index - 1, k.Length + 2);
                                } else {
                                    rtf.Select(index - 1, k.Length + 1);
                                }
                            } else {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index, k.Length + 1);
                                } else {
                                    rtf.Select(index, k.Length);
                                }
                            }
                            if((index <= 0 && (rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + ","))
                                )
                                     ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + ","))
                                )
                                || rtf.Text.ToLower().StartsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + ";")
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
                foreach(string k in SQLSyntax.SQLdarkgreen) {
                    if(rtf.Text.ToLower().Contains(k)) {
                        int index = -1;
                        int selectStart = rtf.SelectionStart;
                        while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                            if(index > 0) {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index - 1, k.Length + 2);
                                } else {
                                    rtf.Select(index - 1, k.Length + 1);
                                }
                            } else {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index, k.Length + 1);
                                } else {
                                    rtf.Select(index, k.Length);
                                }
                            }
                            if((index <= 0 && (rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + ","))
                                )
                                     ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + ","))
                                )
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
                foreach(string k in SQLSyntax.SQLsign) {
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
                foreach(string k in SQLSyntax.SQLquote) {
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
                foreach(string k in SQLSyntax.SQLoperator) {
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
        lockSyntaxHighlighter = false;
    }
    */

    private static void SyntaxHighlightWordlist(this RichTextBox rtf, string[] words, Color col, bool bold, bool upper, bool brackets) {

        if(rtf.Text != null) {
            string[] cwstart = new string[0];
            string[] cwmid = new string[0];
            string[] cwend = new string[0];
            string[] mutations = { " ", "`", ".", ",","\n" };
            if(brackets == true) {
                mutations = mutations.AddItemToArray("(");
                mutations = mutations.AddItemToArray(")");
            } 
            foreach(string k in words) {
                cwstart = cwstart.Clear();
                cwmid = cwmid.Clear();
                cwend = cwend.Clear();
                if(k.Length > 0) {
                    if(k.ToString() == "(" || k.ToString() == ")") {
                        cwmid = cwmid.AddItemToArray(k.ToLower());
                    } else {
                        foreach(string o1 in mutations) {
                            cwstart = cwstart.AddItemToArray(k.ToLower() + o1);
                            foreach(string o2 in mutations) {
                                cwmid = cwmid.AddItemToArray(o1 + k.ToLower() + o2);
                            }
                            cwend = cwend.AddItemToArray(o1 + k.ToLower());
                        }
                    }
                }

                if(rtf.Text.ToLower().Contains(k)) {
                    int index = -1;
                    int selectStart = rtf.SelectionStart;
                    while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                        //Select Word
                        if(index > 0) {
                            if(index + k.Length + 1 <= rtf.Text.Length) {
                                rtf.Select(index - 1, k.Length + 2);    // " from "
                            } else {
                                rtf.Select(index - 1, k.Length + 1);    // " from"
                            }
                        } else {
                            if(index + k.Length + 1 <= rtf.Text.Length) {
                                rtf.Select(index, k.Length + 1);        // "from "
                            } else {
                                rtf.Select(index, k.Length);            // "from"
                            }
                        }
                        if( (index <= 0 && cwstart.Contains(rtf.SelectedText.ToLower())) ||
                            (index >= 0 && cwmid.Contains(rtf.SelectedText.ToLower())) ||
                            (index == (rtf.Text.Length - k.Length) && cwend.Contains(rtf.SelectedText.ToLower()))
                            ) {
                            //Select
                            rtf.Select((index), k.Length);
                            rtf.SelectionColor = col;
                            if(bold == true) {
                                rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                            }
                            if(upper == true) {
                                rtf.SelectedText = rtf.SelectedText.ToUpper();
                            }
                            //Un-Select
                            rtf.Select(selectStart, 0);
                            rtf.SelectionFont = rtf.Font;
                            rtf.SelectionColor = Color.Black;
                        } 
                    }
                }
            }
        }
    }

    private static void SyntaxHighlightBetweenChar(this RichTextBox rtf, string chr, Color col, bool bold) {
        string c = "";
        int sindex = -1;
        int sselectStart = rtf.SelectionStart;
        for(int i = 0; i < rtf.Text.Length; i++) {
            c = rtf.Text.Substring(i, 1).ToString();
            if(c == chr) {
                if(sindex == -1) {
                    sindex = i;
                } else {
                    rtf.Select((sindex) + 1, i - sindex - 1);
                    rtf.SelectionColor = col;
                    if(bold == true) {
                        rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                    } else {
                        rtf.SelectionFont = new Font(rtf.Font, FontStyle.Italic);
                    }
                    rtf.Select(sselectStart, 0);
                    rtf.SelectionFont = rtf.Font;
                    rtf.SelectionColor = Color.Black;
                    sindex = -1;
                }
            }
        }
    }

    private static void BracketHighlight(this RichTextBox rtf, Dictionary<int, int> b, int pos) {
        int open = -1;
        int close = -1;
        int length = -1;
        int sselectStart = rtf.SelectionStart;
        if(pos > 0) {
            foreach(KeyValuePair<int, int> o in b) {
                rtf.Select(o.Key, 1);
                rtf.SelectionColor = Color.DarkGreen;
                rtf.SelectionFont = new Font(rtf.Font, FontStyle.Regular);
                rtf.Select(o.Value, 1);
                rtf.SelectionColor = Color.DarkGreen;
                rtf.SelectionFont = new Font(rtf.Font, FontStyle.Regular);
                if(o.Key <= pos && o.Value >= pos) {
                    if(o.Value - o.Key <= length || length == -1) {
                        open = o.Key;
                        close = o.Value;
                        length = o.Value - o.Key;
                    }
                }
            }
            if(open > -1 && close > -1) {
                rtf.Select(open, 1);
                rtf.SelectionColor = Color.DarkGreen;
                rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                rtf.Select(close, 1);
                rtf.SelectionColor = Color.DarkGreen;
                rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
            }
        }
        rtf.Select(sselectStart, 0);
        rtf.SelectionFont = rtf.Font;
    }

    public static void SyntaxHighlight(this RichTextBox inrtf) {
        if(lockSyntaxHighlighter == false) {
            lockSyntaxHighlighter = true;
            RichTextBox rtf = new RichTextBox();
            int selectStartmem = inrtf.SelectionStart;
            int selectLengthmem = inrtf.SelectionLength;
            rtf.Text = SQLSyntax.fixSQL(inrtf.Text);
            rtf.Select(0, rtf.Text.Length);
            rtf.SelectionFont = rtf.Font;
            rtf.SelectionColor = Color.Black;
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLblue, Color.Blue, true, true, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLdarkgreen, Color.DarkGreen, true, true, true);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLDataTypes, Color.BlueViolet, false, true, true);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLsign, Color.Red, true, false, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLquote, Color.DarkGreen, true, false, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLoperator, Color.Gray, true, false, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLbrackets, Color.DarkGreen, false, false, false);
            SyntaxHighlightBetweenChar(rtf, "'", Color.Green, true);
            SyntaxHighlightBetweenChar(rtf, "#", Color.Magenta, true);
            inrtf.Rtf = rtf.Rtf;
            inrtf.Select(selectStartmem, selectLengthmem);
            lockSyntaxHighlighter = false;
        }
    }
    
    public static void SyntaxHighlight(this RichTextBox inrtf, Dictionary<string, string> TA) {
        if(lockSyntaxHighlighter == false) {
            lockSyntaxHighlighter = true;
            string[] ac = new string[0];
            string[] ak = new string[0];
            foreach(string t in TA.Values) {
                ac = ac.AddItemToArray(t);
            }
            foreach(string k in TA.Keys) {
                ak = ak.AddItemToArray(k);
            }
            RichTextBox rtf = new RichTextBox();
            int selectStartmem = inrtf.SelectionStart;
            int selectLengthmem = inrtf.SelectionLength;
            rtf.Text = SQLSyntax.fixSQL(inrtf.Text);
            rtf.Select(0, rtf.Text.Length);
            rtf.SelectionFont = rtf.Font;
            rtf.SelectionColor = Color.Black;
            //Detect Aliases
            if(ak.Length > 0) {
                SyntaxHighlightWordlist(rtf, ak, Color.DarkRed, true, false, true);
            }
            if(ac.Length > 0) {
                SyntaxHighlightWordlist(rtf, ac, Color.DarkOrange, true, false, true);
            }
            //SQl Keywords and Syntax
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLblue, Color.Blue, true, true, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLdarkgreen, Color.DarkGreen, true, true, true);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLDataTypes, Color.BlueViolet, false, true, true);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLsign, Color.Red, true, false, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLquote, Color.DarkGreen, true, false, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLoperator, Color.Gray, true, false, false);
            SyntaxHighlightWordlist(rtf, SQLSyntax.SQLbrackets, Color.DarkGreen, false, false, false);
            SyntaxHighlightBetweenChar(rtf, "'", Color.Green, true);
            SyntaxHighlightBetweenChar(rtf, "#", Color.Magenta, true);
            //Highlight Brackets
            if(selectStartmem > 0) {
                Dictionary<int, int> OC = BracketPositionMap(rtf);
                if(OC.Count > 0) {
                    BracketHighlight(rtf, OC, selectStartmem);
                }
            }
            inrtf.Rtf = rtf.Rtf;
            inrtf.Select(selectStartmem, selectLengthmem);
            lockSyntaxHighlighter = false;
        }
    }

    public static void SyntaxHighlightBrackets(this RichTextBox inrtf) {
        if(lockSyntaxHighlighter == false) {
            lockSyntaxHighlighter = true;
            RichTextBox rtf = new RichTextBox();
            int selectStartmem = inrtf.SelectionStart;
            int selectLengthmem = inrtf.SelectionLength;
            rtf.Rtf = inrtf.Rtf;
            //Highlight Brackets
            if(selectStartmem > 0) {
                Dictionary<int, int> OC = BracketPositionMap(rtf);
                if(OC.Count > 0) {
                    BracketHighlight(rtf, OC, selectStartmem);
                }
            }
            inrtf.Rtf = rtf.Rtf;
            inrtf.Select(selectStartmem, selectLengthmem);
            lockSyntaxHighlighter = false;
        }
    }

    private static Dictionary<int, int> BracketPositionMap(this RichTextBox rtf) {
        Dictionary<int, int> OC = new Dictionary<int, int>();
        Dictionary<int, int> OB = new Dictionary<int, int>();
        Dictionary<int, int> CB = new Dictionary<int, int>();
        string c = "";
        int openings = 0;
        int[] open = new int[0];
        if(rtf.Text.Contains("(") == true || rtf.Text.Contains(")") == true) {
            for(int i = 0; i < rtf.Text.Length; i++) {
                c = rtf.Text.Substring(i, 1).ToString();
                if(c == "(") {
                    openings++;
                    if(OB.ContainsKey(openings) == false) {
                        open = open.AddItemToArray(openings);
                        OB.Add(openings, i);
                    }
                }
                if(c == ")") {
                    if(open.Length > 0) {
                        CB.Add(open[open.Length - 1], i);
                        open = open.RemoveAt(open.Length - 1);
                    }
                }
            }
        }
        if(OB.Count > 0) {
            foreach(KeyValuePair<int, int> P in OB) {
                if(CB.ContainsKey(P.Key)){
                    OC.Add(P.Value,CB[P.Key]);
                }
            }
        }
        return OC;
    }

    /*
    public static void SyntaxHighlight2(this RichTextBox inrtf, Dictionary<string, string> TA) {
        if(lockSyntaxHighlighter == false) {
            lockSyntaxHighlighter = true;
            RichTextBox rtf = new RichTextBox();
            if(inrtf.Text != null) {
                int selectStartmem = inrtf.SelectionStart;
                //rtf.Rtf = inrtf.Rtf;
                rtf.Text = SQLSyntax.fixSQL(inrtf.Text);
                rtf.Select(0, rtf.Text.Length);
                rtf.SelectionFont = rtf.Font;
                rtf.SelectionColor = Color.Black;
                //BlueBold
                foreach(string k in SQLSyntax.SQLblue) {
                    if(rtf.Text.ToLower().Contains(k)) {
                        int index = -1;
                        int selectStart = rtf.SelectionStart;
                        while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                            if(index > 0) {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index - 1, k.Length + 2);
                                } else {
                                    rtf.Select(index - 1, k.Length + 1);
                                }
                            } else {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index, k.Length + 1);
                                } else {
                                    rtf.Select(index, k.Length);
                                }
                            }
                            if((index <= 0 && (rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + ","))
                                )
                                     ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + ","))
                                )
                                || rtf.Text.ToLower().StartsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + ";")
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
                foreach(string k in SQLSyntax.SQLdarkgreen) {
                    if(rtf.Text.ToLower().Contains(k)) {
                        int index = -1;
                        int selectStart = rtf.SelectionStart;
                        while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                            if(index > 0) {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index - 1, k.Length + 2);
                                } else {
                                    rtf.Select(index - 1, k.Length + 1);
                                }
                            } else {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index, k.Length + 1);
                                } else {
                                    rtf.Select(index, k.Length);
                                }
                            }
                            if((index <= 0 && (rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("," + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals(")" + k.ToString().ToLower() + ","))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("]" + k.ToString().ToLower() + ","))
                                )
                                     ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "(")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "[")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + ","))
                                )
                                || rtf.Text.ToLower().StartsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + ";")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + "\n")
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
                //Table aliases DarkViolet
                foreach(string k in TA.Keys) {
                    if(rtf.Text.ToLower().Contains(k)) {
                        int index = -1;
                        int selectStart = rtf.SelectionStart;
                        while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                            if(index > 0) {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index - 1, k.Length + 2);
                                } else {
                                    rtf.Select(index - 1, k.Length + 1);
                                }
                            } else {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index, k.Length + 1);
                                } else {
                                    rtf.Select(index, k.Length);
                                }
                            }
                            if((index <= 0 && (rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "."))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "."))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "."))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("`" + k.ToString().ToLower().Replace(".", "`.`") + "`"))
                                )
                                || rtf.Text.ToLower().StartsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + ";")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + "\n")
                                ) {
                                rtf.Select((index), k.Length);
                                rtf.SelectionColor = Color.DarkViolet;
                                rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                                rtf.Select(selectStart, 0);
                                rtf.SelectionFont = rtf.Font;
                                rtf.SelectionColor = Color.Black;
                            }
                        }
                    }
                }
                //Table aliases DarkOrange
                foreach(string k in TA.Values) {
                    if(rtf.Text.ToLower().Contains(k)) {
                        int index = -1;
                        int selectStart = rtf.SelectionStart;
                        while((index = rtf.Text.ToLower().IndexOf(k.ToLower(), (index + 1))) != -1) {
                            if(index > 0) {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index - 1, k.Length + 2);
                                } else {
                                    rtf.Select(index - 1, k.Length + 1);
                                }
                            } else {
                                if(index + k.Length + 1 <= rtf.Text.Length) {
                                    rtf.Select(index, k.Length + 1);
                                } else {
                                    rtf.Select(index, k.Length);
                                }
                            }
                            if((index <= 0 && (rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(k.ToString().ToLower() + "."))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals(" " + k.ToString().ToLower() + "."))
                                )
                                ||
                                (index > 0 && (rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + " ")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "\n")
                                    || rtf.SelectedText.ToLower().Equals("\n" + k.ToString().ToLower() + "."))
                                )
                                || rtf.Text.ToLower().StartsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + " ")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + ";")
                                || rtf.Text.ToLower().EndsWith(k.ToString().ToLower() + "\n")
                                ) {
                                rtf.Select((index), k.Length);
                                rtf.SelectionColor = Color.DarkOrange;
                                rtf.SelectionFont = new Font(rtf.Font, FontStyle.Bold);
                                rtf.Select(selectStart, 0);
                                rtf.SelectionFont = rtf.Font;
                                rtf.SelectionColor = Color.Black;
                            }
                        }
                    }
                }
                //redBold
                foreach(string k in SQLSyntax.SQLsign) {
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
                foreach(string k in SQLSyntax.SQLquote) {
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
                foreach(string k in SQLSyntax.SQLoperator) {
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
        lockSyntaxHighlighter = false;
    }
    */
}
