using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myanmar2Correction
{
    class Corrector2
    {
            string[] C = new string[] { "\u1000", "\u1001", "\u1002", "\u1003", "\u1004", "\u1005", "\u1006", "\u1007", "\u1008", "\u1009", "\u100A", "\u100B", "\u100C", "\u100D", "\u100E", "\u100F", "\u1010", "\u1011", "\u1012", "\u1013", "\u1014", "\u1015", "\u1016", "\u1017", "\u1018", "\u1019", "\u101A", "\u101B", "\u101C", "\u101D", "\u101E", "\u101F", "\u1020", "\u1021" };
            string[] V = new string[] { "\u102B", "\u102C", "\u102D", "\u102E", "\u102F", "\u1030", "\u1031", "\u1032", "\u1031\u102B", "\u1031\u102C", "\u1031\u102B\u103A", "\u1031\u102C\u103A", "\u1036", "\u102D\u102F" };
            string[] M = new string[] { "\u103B", "\u103C", "\u103D", "\u103E", "\u103B\u103D", "\u103C\u103D", "\u103B\u103E", "\u103C\u103E", "\u103D\u103E", "\u103C\u103D\u103E", "\u103B\u103D\u103E" };
            string[] Dup = new string[] { "\u1037", "\u1036", "\u102D", "\u102E", "\u102F", "\u1030", "\u1032", "\u103D", "\u103E", "\u1031" };
            string[] ForWa = new string[] { "\u1037", "\u1036", "102D", "\u102E", "\u102F", "\u1030", "\u1032", "\u103D", "\u103E", "\u103A" };
            string[] ForPaNga = new string[] { "\u1001", "\u1002", "\u1004", "\u1012", "\u1015", "\u101D" };
            string[] ForThaWaiHtoe = new string[] { "\u102B", "\u102C", "\u102D", "\u102E", "\u102F", "\u1030", "\u1032", "\u1036", "\u1037", "\u1038", "\u103A", " " };
            string[] NotMedialRa = new string[] { "\u1008", "\u1009", "\u100A", "\u100B", "\u100C", "\u100D", "\u100E", "\u101B", "\u1020" };
            string[] Number = new string[] { "\u1040", "\u1041", "\u1042", "\u1043", "\u1044", "\u1045", "\u1046", "\u1047", "\u1048", "\u1049" };
            public string Cottection(string  strbil)
            {
                string inputStr = "";
               
                inputStr = strbil.Replace("\u102F\u102D", "\u102D\u102F");
                inputStr = inputStr.Replace("\u1005\u103B", "\u1008");
                inputStr = inputStr.Replace("\u1025\u103A", "\u1009\u103A");
                inputStr = inputStr.Replace("\u1025\u1039", "\u1009\u1039");
                inputStr = inputStr.Replace("\u103B\u103A", "\u103A\u103B");
                inputStr = inputStr.Replace("\u1031\u1031", "\u1031");
                char[] ch_arr = inputStr.ToCharArray();
                string temp = "";
                for (int i = 0; i < ch_arr.Length; i++)
                {
                    if (Dup.Contains(ch_arr[i].ToString()))//Checking Duplicate
                    {
                        if (ch_arr[i - 1].ToString() == ch_arr[i].ToString())
                        {
                            temp += "";
                        }//End Checking Duplicate
                        else
                        {
                            if (ch_arr[i].ToString() == "\u102F")//Checking ု
                            {
                                if (ch_arr[i - 1].ToString() == "\u1030")//ူ
                                {
                                    temp += "";
                                }
                                else
                                {
                                    if (i + 1 == ch_arr.Length)
                                    {
                                        temp += ch_arr[i].ToString();
                                    }
                                    else
                                    {
                                        if (ch_arr[i + 1].ToString() == "\u1030")//ူ
                                        {
                                            temp += "";
                                        }
                                        else
                                        {
                                            temp += ch_arr[i].ToString();
                                        }
                                    }
                                }
                            }//End Checking ု
                            else if (ch_arr[i].ToString() == "\u1030")//Checking ူ
                            {
                                if (ch_arr[i - 1].ToString() == "\u102D" || ch_arr[i - 1].ToString() == "\u102E" || ch_arr[i - 1].ToString() == "\u102F")//ိ|ီ|ု
                                {
                                    temp += "\u102F";//ု
                                }
                                else
                                {
                                    if (i + 1 == ch_arr.Length)
                                    {
                                        temp += ch_arr[i].ToString();
                                    }
                                    else
                                    {
                                        if (ch_arr[i + 1].ToString() == "\u1036" || ch_arr[i + 1].ToString() == "\u102F")//ံ|ု
                                        {
                                            temp += "\u102F";//ု
                                        }
                                        else
                                        {
                                            temp += ch_arr[i].ToString();
                                        }
                                    }
                                }

                            }//End Checking ူ
                            else if (ch_arr[i].ToString() == "\u102E")//Checking ီ
                            {
                                if (i + 1 == ch_arr.Length)
                                {
                                    temp += ch_arr[i].ToString();
                                }
                                else
                                {
                                    if (ch_arr[i + 1].ToString() == "\u1030" || ch_arr[i + 1].ToString() == "\u102F")//ူု
                                    {
                                        temp += "\u102D";//ိ
                                    }
                                    else
                                    {
                                        temp += ch_arr[i].ToString();
                                    }
                                }
                            }//End Checking ီ
                                //checking thawahtoe
                            else if (ch_arr[i].ToString() == "\u1031")
                            {
                                if (Number.Contains(ch_arr[i + 1].ToString()))
                                {
                                    temp += "";
                                }
                                else
                                {
                                    temp += ch_arr[i].ToString();
                                }

                            }
                            //else if (ch_arr[i].ToString() == "\u1031")//Checking ေ
                            //{
                            //    if (i == 0)
                            //    {
                            //        temp += "";
                            //    }
                            //    else
                            //    {
                            //        if (ForThaWaiHtoe.Contains(ch_arr[i - 1].ToString()))
                            //        {
                            //            temp += "";
                            //        }
                            //        else
                            //        {
                            //            if (C.Contains(ch_arr[i - 1].ToString()))
                            //            {
                            //                temp += ch_arr[i].ToString();
                            //            }
                            //            else
                            //            {
                            //                temp += "";
                            //            }
                            //        }
                            //    }//End Checking ေ
                            //}
                            else
                            {
                                temp += ch_arr[i].ToString();
                            }
                        }
                    }
                    else
                    {

                        if (ch_arr[i].ToString() == "\u101D")//Checking Wa
                        {
                            if (i == 0)
                            {
                                temp += ch_arr[i].ToString();
                            }
                            else
                            {
                                if (!Number.Contains(ch_arr[i - 1].ToString()))
                                {
                                    temp += ch_arr[i].ToString();
                                }
                                else
                                {
                                    if (i + 1 == ch_arr.Length)
                                    {
                                        temp += "\u1040";
                                    }
                                    else
                                    {
                                        if (!Number.Contains(ch_arr[i + 1].ToString()))
                                        {
                                            temp += ch_arr[i].ToString();
                                        }
                                        else
                                        {
                                            temp += "\u1040";
                                        }
                                    }
                                }

                            }
                        }//End Checking Wa
                        else if (Number.Contains(ch_arr[i].ToString()))//no and vowel
                        {
                            if (ch_arr[i - 1].ToString() == "\u1031")
                            {
                                if (ch_arr[i].ToString() == "\u1047")
                                {
                                    temp += "ရေ";  //replace ၇  ရ
                                    //temp = temp.Replace("\u200B\u1031","");
                                }
                                else if (ch_arr[i].ToString() == "\u1048")
                                {
                                    temp += "​ဂေ";   //replace ဂ  ၈
                                }
                                else if (ch_arr[i].ToString() == "\u1040")
                                {
                                    temp += "ဝေ";   //replace ၀ ဝ
                                }
                            }
                            else
                            {
                                temp+=ch_arr[i].ToString();
                            }
                        }
                        else if (ch_arr[i].ToString() == "\u1040")//Checking Zero
                        {
                            if (i == 0)
                            {
                                temp += ch_arr[i].ToString();
                            }
                            else
                            {
                                if (Number.Contains(ch_arr[i - 1].ToString()))
                                {
                                    temp += ch_arr[i].ToString();
                                }
                                else
                                {
                                    if (i + 1 == ch_arr.Length)
                                    {
                                        temp += "\u101D";
                                    }
                                    else
                                    {
                                        if (Number.Contains(ch_arr[i + 1].ToString()))
                                        {
                                            temp += ch_arr[i].ToString();
                                        }
                                        else
                                        {
                                            temp += "\u101D";
                                        }
                                    }
                                }

                            }
                        }//End Checking Zero
                        else if (ch_arr[i].ToString() == "\u102C")//Checking Yae Cha
                        {
                            if (ForPaNga.Contains(ch_arr[i - 1].ToString()))
                            {
                                temp += "\u102B";
                            }
                            else temp += ch_arr[i].ToString();
                        }//End Checking Yae Cha
                        //Checking For ြ
                        else if (C.Contains(ch_arr[i].ToString()))//Testing Consonant
                        {
                            if (NotMedialRa.Contains(ch_arr[i].ToString()))//ဈဉညဋဌဍၓရဠ
                            {
                                temp += ch_arr[i].ToString();
                            }

                            else
                            {
                                if (i == 0)
                                {
                                    temp += ch_arr[i].ToString();
                                }
                                else
                                {
                                    if (ch_arr[i - 1].ToString() == "\u1031")//checking ေ
                                    {
                                        if (i - 1 == 0)
                                        {
                                            temp += ch_arr[i].ToString() + "\u1031";
                                        }
                                        else
                                        {
                                            if (ForThaWaiHtoe.Contains(ch_arr[i - 2].ToString()))//error
                                            {
                                                temp += ch_arr[i].ToString() + "\u1031";
                                            }
                                            else
                                            {
                                                temp += ch_arr[i].ToString();
                                            }
                                        }
                                    }
                                    else if (ch_arr[i - 1].ToString() == "\u103C")
                                    {
                                        if (C.Contains(ch_arr[i - 2].ToString()))
                                        {
                                            if (NotMedialRa.Contains(ch_arr[i - 2].ToString()))
                                            {
                                                temp += ch_arr[i].ToString() + "\u103C";
                                            }
                                            else
                                            {
                                                temp += ch_arr[i].ToString();
                                            }
                                        }
                                        else
                                        {
                                            temp += ch_arr[i].ToString() + "\u103C";
                                        }
                                    }
                                    else
                                    {
                                        temp += ch_arr[i].ToString();
                                    }
                                }
                            }
                        }
                        else if (ch_arr[i].ToString() == "\u103C")//Testing ြ
                        {
                            if (C.Contains(ch_arr[i - 1].ToString()))
                            {
                                if (NotMedialRa.Contains(ch_arr[i - 1].ToString()))
                                {
                                    temp += "";
                                }
                                else
                                {
                                    temp += ch_arr[i].ToString();
                                }
                            }
                            else
                            {
                                if (i + 1 == ch_arr.Length)
                                {
                                    temp += ch_arr[i].ToString();
                                }
                                else
                                {
                                    if (C.Contains(ch_arr[i + 1].ToString()))
                                    {
                                        temp += "";
                                    }
                                    else
                                    {
                                        temp += ch_arr[i].ToString();
                                    }
                                }
                            }
                        }
                        //End Checking ြ
                        else temp += ch_arr[i].ToString();
                    }
                }
                return  temp;
                //resultStr = temp;
                //return resultStr;
            }
        }
    }

