using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

public static class Extensions {

    public static T[] PAdd<T>(this T[] original, T itemToAdd) {
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


    public static T[] PClear<T>(this T[] original) {
        T[] finalArray = new T[0];
        return finalArray;
    }

    public static T[] PRemove<T>(this T[] original, int index) {
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

}

