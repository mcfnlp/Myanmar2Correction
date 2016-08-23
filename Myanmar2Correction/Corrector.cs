using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MMNLPTeam;

namespace Myanmar2Correction
{
    class Corrector
    {
        public static string Correction1(string input)
        {

            #region declarationy
           // SyllableCluster syll = new SyllableCluster();
            string[] C = { "က", "ခ", "ဂ", "ဃ", "င", "စ", "ဆ", "ဇ", "ဈ", "ဉ", "ည", "ဋ", "ဌ", "ဍ", "ဎ", "ဏ", "တ", "ထ", "ဒ", "ဓ", "န", "ပ", "ဖ", "ဗ", "ဘ", "မ", "ယ", "ရ", "လ", "ဝ", "သ", "ဟ", "ဠ", "အ" };
            string[] M = { "\u103B", "\u103C", "\u103D", "\u103E" };
            string[] V = { "\u102B", "\u102C", "\u102D", "\u102E", "\u102F", "\u1030", "\u1031", "\u1032", "\u1036" };
            string[] IV = { "ဣ", "ဤ", "ဥ", "ဦ", "ဧ", "ဩ", "ဪ", "၎" };
            string[] T = { "\u1037", "\u1038", "\u103A", "\u1039" };
            string[] D = { "၀", "၁", "၂", "၃", "၄", "၅", "၆", "၇", "၈", "၉" };
             string[] NotMedialRa = new string[] { "\u1008", "\u1009", "\u100A", "\u100B", "\u100C", "\u100D", "\u100E", "\u101B", "\u1020" };
           
            string unistr = null;
            #endregion

            unistr = input;
            string pattern = "\u102D+|\u102E+|\u1031+|\u103D+|\u103E+|\u1032+|\u1037+|\u1036+|\u103A+";
            unistr = Regex.Replace(unistr, pattern, new MatchEvaluator(childdeldul));

            unistr = Regex.Replace(unistr, C[5] + M[0], C[8]);
            unistr = Regex.Replace(unistr, C[30] + M[1], IV[5]);
            unistr = Regex.Replace(unistr, C[30] + M[1] + V[6] + V[1] + T[2], IV[6]);
            unistr = Regex.Replace(unistr, IV[5] + V[6] + V[1] + T[2], IV[6]);
            unistr = Regex.Replace(unistr, IV[2] + V[3], IV[3]);
            unistr = Regex.Replace(unistr, IV[2] + T[3], C[9] + T[3]);
            unistr = Regex.Replace(unistr, IV[2] + T[2], C[9] + T[2]);
            unistr = Regex.Replace(unistr, IV[2] + V[1], C[9] + V[1]);
            //unistr = Regex.Replace(unistr, IV[2] + "\u103A", C[9] + "\u103A");
            unistr = Regex.Replace(unistr, D[4] + C[4] + T[2] + T[1], IV[7] + C[4] + T[2] + T[1]);
            unistr = Regex.Replace(unistr, T[0] + T[2], T[2] + T[0]);
            unistr = Regex.Replace(unistr, T[1] + T[2], T[2] + T[1]);

            #region Medial reordering

            unistr = Regex.Replace(unistr, M[3] + M[0], M[0] + M[3]);
            unistr = Regex.Replace(unistr, M[3] + M[1], M[1] + M[3]);
            unistr = Regex.Replace(unistr, M[3] + M[2], M[2] + M[3]);
            unistr = Regex.Replace(unistr, M[2] + M[0], M[0] + M[2]);
            unistr = Regex.Replace(unistr, M[2] + M[1], M[1] + M[2]);
            unistr = Regex.Replace(unistr, M[3] + M[2] + M[1] + "|" + M[3] + M[1] + M[2] + "|" + M[2] + M[3] + M[1] + "|" + M[2] + M[1] + M[3] + "|" + M[1] + M[3] + M[2], M[1] + M[2] + M[3]);
            unistr = Regex.Replace(unistr, M[3] + M[2] + M[0] + "|" + M[3] + M[0] + M[2] + "|" + M[2] + M[3] + M[0] + "|" + M[2] + M[0] + M[3] + "|" + M[0] + M[3] + M[2], M[0] + M[2] + M[3]);
            //unistr = Regex.Replace(unistr,M[1]+C[0],C[0]+M[1]);   
            //unistr = Regex.Replace(unistr, M[1] + C[1], C[1] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[2], C[2] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[4], C[4] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[16], C[16] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[18], C[18] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[19], C[19] + M[1]);
            // unistr = Regex.Replace(unistr, M[1] + C[21], C[21] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[22], C[22] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[23], C[23] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + C[25], C[25] + M[1]);
            //unistr = Regex.Replace(unistr, M[1] + D[8], C[2] + M[1]);
            
            #endregion

            # region Vowel reordering

            unistr = Regex.Replace(unistr, V[8] + V[4], V[4] + V[8]);
            unistr = Regex.Replace(unistr, V[4] + V[2], V[2] + V[4]);
            unistr = Regex.Replace(unistr, V[8] + V[2], V[2] + V[8]);
            unistr = Regex.Replace(unistr, T[0] + V[4], V[4] + T[0]);
            unistr = Regex.Replace(unistr, T[0] + V[7], V[7] + T[0]);
            unistr = Regex.Replace(unistr, T[0] + V[8], V[8] + T[0]);

            #endregion

            # region Contracted words
            unistr = Regex.Replace(unistr, C[26] + V[6] + V[1] + C[0] + M[0] + T[2] + V[1], C[26] + V[6] + V[1] + C[0] + T[2] + M[0] + V[1]);
            unistr = Regex.Replace(unistr, C[20] + V[4] + T[2], C[20] + T[2] + V[4]);
            #endregion

            # region two times typing
            unistr = Regex.Replace(unistr, "\u103A\u103A", "\u103A");
            unistr = Regex.Replace(unistr,"\u1031\u1031","\u1031");
            unistr = Regex.Replace(unistr, "ီိ", "ီ");
            unistr = Regex.Replace(unistr, "ိီ", "ီ");
            unistr = Regex.Replace(unistr, "ဦီ", "ဦ");
            unistr = Regex.Replace(unistr, "ဦိ", "ဦ");
            
            //unistr = Regex.Replace(unistr, "ိိ", "ိ");
            //unistr = Regex.Replace(unistr, "ွွ", "ွ");
            //unistr = Regex.Replace(unistr, "ှှ", "ှ");
            //unistr = Regex.Replace(unistr, "ဲဲ", "ဲ");
            //unistr = Regex.Replace(unistr, "ံံ", "ံ");
            //unistr = Regex.Replace(unistr, "့့", "့");
            #endregion

            #region Recognition of digit as consonant
            unistr = Regex.Replace(unistr, D[0] + T[2], C[29] + T[2]);
            unistr = Regex.Replace(unistr, D[7] + T[2], C[27] + T[2]);
            unistr = Regex.Replace(unistr, D[8] + T[2], C[2] + T[2]);
            
            unistr = Regex.Replace(unistr, D[0] + T[3], C[29] + T[3]);
            unistr = Regex.Replace(unistr, D[7] + T[3], C[27] + T[3]);
            unistr = Regex.Replace(unistr, D[8] + T[3], C[2] + T[3]);

            unistr = Regex.Replace(unistr, D[0] + "(?<vowel>[" + V[0] + "-" + V[8] + "])", C[29] + "${vowel}");
            unistr = Regex.Replace(unistr, D[7] + "(?<vowel>[" + V[0] + "-" + V[8] + "])", C[27] + "${vowel}");
            unistr = Regex.Replace(unistr, D[8] + "(?<vowel>[" + V[0] + "-" + V[8] + "])", C[2] + "${vowel}");

            unistr = Regex.Replace(unistr, D[0] + "(?<medial>[" + M[0] + "-" + M[3] + "])", C[29] + "${medial}");
            unistr = Regex.Replace(unistr, D[7] + "(?<medial>[" + M[0] + "-" + M[3] + "])", C[27] + "${medial}");
            unistr = Regex.Replace(unistr, D[8] + "(?<medial>[" + M[0] + "-" + M[3] + "])", C[2] + "${medial}");

            unistr = Regex.Replace(unistr, D[0] + "(?<finale>([\u1000-\u1031][\u1039-\u103A]))", C[29] + "${finale}");
            unistr = Regex.Replace(unistr, D[7] + "(?<finale>([\u1000-\u1031][\u1039-\u103A]))", C[27] + "${finale}");
            unistr = Regex.Replace(unistr, D[8] + "(?<finale>([\u1000-\u1031][\u1039-\u103A]))", C[2] + "${finale}");

            //editing  for ​ေ၇   ​ေ၀  ​ေ၈
            //unistr = Regex.Replace(unistr, V[7] + D[7], V[7] + C[27]);
            unistr=Regex.Replace(unistr,"\u1031\u1047","\u101B\u1031");
            unistr = Regex.Replace(unistr, "\u1031\u1048", "\u1002\u1031");
            unistr = Regex.Replace(unistr, "\u1031\u1040", "\u101D\u1031");
            #endregion

            #region reordering
            unistr = Regex.Replace(unistr, "(?<upper>[\u102D\u102E\u1036\u1032])(?<M>[\u103B-\u103E]+)", "${M}${upper}"); //reordering storage order
            unistr = Regex.Replace(unistr, "(?<DVs>[\u1036\u1037\u1038]+)(?<lower>[\u102F\u1030])", "${lower}${DVs}"); //reordering storage order
            unistr = unistr.Replace("့်", "့်");
            #endregion
            #region Zero,Eight and seven
            unistr = Regex.Replace(unistr, "၀(?<MV>[\u102B-\u103E]+)", "ဝ${MV}"); //zero and Wa
            unistr = Regex.Replace(unistr, "၀(?<C>[\u1000-\u1021])(?<killer>[\u1039\u103A]?)", "ဝ${C}${killer}"); //zero and Wa
            unistr = Regex.Replace(unistr, "(?<A>[\u1000-\u103E])၀", "${A}ဝ"); //zero and Wa
            unistr = Regex.Replace(unistr, "၈(?<MV>[\u102B-\u103E]+)", "ဂ${MV}"); //zero and Wa
            unistr = Regex.Replace(unistr, "၈(?<C>[\u1000-\u1021])(?<killer>[\u1039\u103A]?)", "ဂ${C}${killer}"); //zero and Wa
            unistr = Regex.Replace(unistr, "၇(?<MV>[\u102B-\u103E]+)", "ရ${MV}"); //zero and Wa
            unistr = Regex.Replace(unistr, "၇(?<C>[\u1000-\u1021])(?<killer>[\u1039\u103A]?)", "ရ${C}${killer}"); //zero and Wa
            #endregion
            #region thawaihtoe and yetyite
            unistr = Regex.Replace(unistr, "\u1031(?<C1>[\u1000-\u1021])\u103C(?<C2>[\u1000-\u1021])", "\u1031${C1}${C2}\u103C"); //Yetyite
            unistr = Regex.Replace(unistr, "(?<C1>[^\u1000-\u1021]+)\u103C(?<C2>[\u1000-\u1021])", "${C1}${C2}\u103C"); //Yetyite
            unistr = Regex.Replace(unistr, "(?<C2>[\u1000-\u1021])\u103C(?<B>[\u1037]?)\u103A", "\u103C${C2}${B}\u103A"); //Yetyite
            //unistr = Regex.Replace(unistr, "\u1031","\u1031\u200B"); 
            unistr = Regex.Replace(unistr, "(?<C1>[^\u1000-\u1021]+)\u1031(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)", "${C1}\u1031\u200B${C2}${M2}"); //Tha wai htoe
            unistr = Regex.Replace(unistr, "(?<M1>[^\u103B-\u103E]+)\u1031(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)(?<T>[^\u1031]+)", "${M1}\u1031\u200B${C2}${M2}${T}"); //Tha wai htoe
            unistr = Regex.Replace(unistr, "(?<C1>[\u1000-\u1021])(?<M1>[\u103B-\u103E]*)\u1031\u200B(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)(?<T>[^\u1031]+)", "${C1}${M1}\u1031${C2}${M2}${T}"); //Tha wai htoe
            unistr = Regex.Replace(unistr, "(?<C1>[\u1000-\u1021])(?<M1>[\u103B-\u103E]*)\u1031\u200B(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)(?<V>[\u102B-\u1036]*)", "${C1}${M1}\u1031${C2}${M2}${V}"); //Tha wai htoe
            unistr = Regex.Replace(unistr, "\u1031\u200B(?<C2>[\u1000-\u1021])", "${C2}\u1031"); //Tha wai htoe
            unistr = Regex.Replace(unistr, "(?<C1>[\u1000-\u1021])\u1031(?<M1>[\u103B-\u103E]+)", "${C1}${M1}\u1031"); //Tha wai htoe
            unistr = Regex.Replace(unistr, "(?<C1>[^\u1000-\u1021]+)\u103C(?<C2>[\u1000-\u1021])(?<M>[\u103D\u103E]*)\u1031", "${C1}${C2}\u103C${M}\u1031"); //yetyite
            //unistr = Regex.Replace(unistr, "(?<M1>[^\u103B-\u103E]+)\u1031(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)(?<T>[^\u1031]+)", "${M1}${C2}${M2}\u1031${T}"); //Tha wai htoe
            //unistr = Regex.Replace(unistr, "(?<C1>[^\u1000-\u1021]+)\u1031\u200B(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)(?<C3>[^\u1000-\u1021])", "${C1}${C2}${M2}\u1031${C3}"); //Tha wai htoe
            //unistr = Regex.Replace(unistr, "(?<C1>[^\u1000-\u1021]+)(?<M1>[^\u103B-\u103E]+)\u1031\u200B(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)(?<C3>[^\u1000-\u1021])", "${C1}${M1}${C2}${M2}\u1031${C3}"); //Tha wai htoe
            //unistr = Regex.Replace(unistr, "\u200B", "");
          //  unistr = Regex.Replace(unistr, "(?<M1>[^\u103B-\u103E]+)\u1031(?<C2>[\u1000-\u1021])(?<M2>[\u103B-\u103E]*)", "${M1}${C2}${M2}\u1031"); //Tha wai htoe
            //unistr = Regex.Replace(unistr, "\u1031(?<C2>[\u1000-\u1021])", "${C2}\u1031"); //Tha wai htoe
           // unistr = Regex.Replace(unistr, "\u103C(?<C2>[\u1000-\u1021])", "${C2}\u103C"); //Tha wai htoe
            #endregion
            unistr = Regex.Replace(unistr, "(?<C>[\u1000-\u1021])(?<V>[\u102B-\u1036]+)(?<M>[\u103B-\u103E]+)", "${C}${M}${V}");
            unistr = Regex.Replace(unistr, "(?<C1>[^ကခဂငဆတဒပဖဗမသ]+)ြ(?<M>[\u103D\u103E]*)(?<V>[\u102B-\u1036]*)(?<T>[\u1037\u1038]*)(?<C2>[\u1000-\u1021])(?<NN>[^\u103A\u103C]+)", "${C1}${M}${V}${T}${C2}ြ${NN}"); 
            #region  edit ြ  ​ေ+၇ ၈ ၀
            //char[] ch_arr = unistr.ToCharArray();
            //    string temp = "";
            //    for (int i = 0; i < ch_arr.Length; i++)
            //    {
            //        //Corrector2 correct = new Corrector2();
            //        //unistr = correct.Cottection(unistr);
            //        if (C.Contains(ch_arr[i].ToString()))//Testing Consonant
            //        {
            //            if (NotMedialRa.Contains(ch_arr[i].ToString()))//ဈဉညဋဌဍၓရဠ
            //            {
            //                temp += ch_arr[i].ToString();
            //            }

            //            else
            //            {
            //                if (i == 0)
            //                {
            //                    temp += ch_arr[i].ToString();
            //                }
            //                else
            //                {

            //                    if (ch_arr[i - 1].ToString() == "\u103C")
            //                    {
            //                        if (C.Contains(ch_arr[i - 2].ToString()))
            //                        {
            //                            if (NotMedialRa.Contains(ch_arr[i - 2].ToString()))
            //                            {
            //                                temp += ch_arr[i].ToString() + "\u103C";
            //                            }
            //                            else
            //                            {
            //                                temp += ch_arr[i].ToString();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            temp += ch_arr[i].ToString() + "\u103C";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        temp += ch_arr[i].ToString();
            //                    }
            //                }
            //            }
            //        }
            //        else if (ch_arr[i].ToString() == "\u103C")//Testing ြ
            //        {
            //            if (C.Contains(ch_arr[i - 1].ToString()))
            //            {
            //                if (NotMedialRa.Contains(ch_arr[i - 1].ToString()))
            //                {
            //                    temp += "";
            //                }
            //                else
            //                {
            //                    temp += ch_arr[i].ToString();
            //                }
            //            }
            //            else
            //            {
            //                if (i + 1 == ch_arr.Length)
            //                {
            //                    temp += ch_arr[i].ToString();
            //                }
            //                else
            //                {
            //                    if (C.Contains(ch_arr[i + 1].ToString()))
            //                    {
            //                        temp += "";
            //                    }
            //                    else
            //                    {
            //                        temp += ch_arr[i].ToString();
            //                    }
            //                }
            //            }
            //        }
            //        else temp += ch_arr[i].ToString();
            //    }
            //            //End Checking ြ
            #endregion
            return unistr;
        }

        public static string childdeldul(Match m)
        {
            string x = m.Value;

            if (x.Length>1)
            {
                x = x.Remove(1);
            }
            //else x = x;
            return x;
        }
    }
}
