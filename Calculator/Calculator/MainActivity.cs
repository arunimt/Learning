using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Calculator;

namespace Calculator
{
    [Activity(Label = "Calculator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);  

        
            #region Get UI controls 
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            TextView textView = FindViewById<TextView>(Resource.Id.textView);
            EditText editText = FindViewById<EditText>(Resource.Id.editText);
            TextView textResult = FindViewById<TextView>(Resource.Id.txtResult);
            Button btnClear = FindViewById<Button>(Resource.Id.btnClear);
            Button btnDel = FindViewById<Button>(Resource.Id.btnDel);
            Button btnDivide = FindViewById<Button>(Resource.Id.btnDivide);
            Button btnMultiply = FindViewById<Button>(Resource.Id.btnMultiply);
            Button btnSeven = FindViewById<Button>(Resource.Id.btnSeven);
            Button btnEight = FindViewById<Button>(Resource.Id.btnEight);
            Button btnNine = FindViewById<Button>(Resource.Id.btnNine);
            Button btnSubtract = FindViewById<Button>(Resource.Id.btnSubtract);
            Button btnFour = FindViewById<Button>(Resource.Id.btnFour);
            Button btnFive = FindViewById<Button>(Resource.Id.btnFive);
            Button btnSix = FindViewById<Button>(Resource.Id.btnSix);
            Button btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            Button btnOne = FindViewById<Button>(Resource.Id.btnOne);
            Button btnTwo = FindViewById<Button>(Resource.Id.btnTwo);
            Button btnThree = FindViewById<Button>(Resource.Id.btnThree);
            Button btnDot = FindViewById<Button>(Resource.Id.btnDot);
            Button btnPercent = FindViewById<Button>(Resource.Id.btnPercent);
            Button btnZero = FindViewById<Button>(Resource.Id.btnZero);
            Button btnEqual = FindViewById<Button>(Resource.Id.btnEqual);
            #endregion

            #region variable initialization
            string operation = string.Empty;
            double result = 0;
            editText.Text = "0";
            btnClear.Text = editText.Text == "0" ? "AC" : "C";
            #endregion

            #region btn genric
            btnClear.Click += (sender, e) =>
            {
                textView.Text = "";
                editText.Text = "0";
                textResult.Text = "0";
            };
            btnDel.Click += (sender, e) =>
            {
                if (!textView.Text.Contains("-------"))
                {
                    if (editText.Text != string.Empty)
                    {
                        if (textView.Text != string.Empty)
                        {
                            result = textResult.Text != string.Empty ? double.Parse(textResult.Text) : 0;
                            string numEdit;
                            string[] arr = editText.Text.Split(' ');
                            if (arr.Length > 1)
                            {
                                if (arr[1].Length > 0)
                                {
                                    string[] decArr = editText.Text.Split('.');
                                    if (decArr.Length > 1)
                                    {
                                        numEdit = decArr[1].Length > 1 ? arr[1].Remove(arr[1].Length - 1) : arr[1].Remove(arr[1].Length - 2);
                                    }
                                    else
                                    {
                                        numEdit = arr[1].Remove(arr[1].Length - 1);
                                    }
                                    textResult.Text = Core.CalculatorHelper.CalculateDel(result, double.Parse(arr[1]), numEdit == "" ? 0 : double.Parse(numEdit), arr[0]);
                                    if (numEdit != "")
                                    {
                                        editText.Text = arr[0] + " " + numEdit;
                                    }
                                    else
                                    {
                                        string[] arrHistory = textView.Text.Split('\n');
                                        editText.Text = arrHistory[arrHistory.Length - 2];
                                        string str = "";
                                        for (int i = 0; i < arrHistory.Length - 2; i++)
                                        {
                                            str = str + arrHistory[i] + "\n";
                                        }
                                        textView.Text = str;
                                    }
                                }
                                else
                                {
                                    editText.Text = "0";
                                    textView.Text = "";
                                }
                            }
                            else
                            {
                                string[] arrHistory = textView.Text.Split('\n');
                                editText.Text = arrHistory[arrHistory.Length - 2];
                                string str = "";
                                for (int i = 0; i < arrHistory.Length - 2; i++)
                                {
                                    str = str + arrHistory[i] + "\n";
                                }
                                textView.Text = str;
                            }
                        }
                        else
                        {
                            string[] arr = editText.Text.Split('.');
                            if (editText.Text.Length > 1)
                            {
                                editText.Text = arr[1].Length > 1 ? editText.Text.Remove(editText.Text.Length - 1) : editText.Text.Remove(editText.Text.Length - 2);
                                textResult.Text = editText.Text;
                            }
                            else
                            {
                                editText.Text = "0";
                                textResult.Text = "";
                            }
                        }
                    }
                    else
                    {
                        editText.Text = "0";
                    }
                }
            };
            #endregion

            #region btn Operations
            btnDivide.Click += (sender, e) =>
                {
                    if (editText.Text.Length != 2)
                        textView.Text = textView.Text + editText.Text + "\n";

                    editText.Text = btnDivide.Text + " ";
                    if (textResult.Text != string.Empty)
                    {
                        result = double.Parse(textResult.Text);
                    }
                    if (textView.LineCount > 5)
                    {
                        textView.ScrollTo(0, ((textView.LineCount - 5) * textView.LineHeight));
                    }

                };
            btnMultiply.Click += (sender, e) =>
            {
                if (editText.Text.Length != 2)
                    textView.Text = textView.Text + editText.Text + "\n";
                editText.Text = btnMultiply.Text + " ";
                if (textResult.Text != string.Empty)
                {
                    result = double.Parse(textResult.Text);
                }
                if (textView.LineCount > 5)
                {
                    textView.ScrollTo(0, ((textView.LineCount - 5) * textView.LineHeight));
                }
            };
            btnSubtract.Click += (sender, e) =>
            {
                if (editText.Text.Length != 2)
                    textView.Text = textView.Text + editText.Text + "\n";
                editText.Text = btnSubtract.Text + " ";
                if (textResult.Text != string.Empty)
                {
                    result = double.Parse(textResult.Text);
                }
                if (textView.LineCount > 5)
                {
                    textView.ScrollTo(0, ((textView.LineCount - 5) * textView.LineHeight));
                }
            };
            btnAdd.Click += (sender, e) =>
            {
                if (editText.Text.Length != 2)
                    textView.Text = textView.Text + editText.Text + "\n";
                editText.Text = btnAdd.Text + " ";
                if (textResult.Text != string.Empty)
                {
                    result = double.Parse(textResult.Text);
                }
                if (textView.LineCount > 5)
                {
                    textView.ScrollTo(0, ((textView.LineCount - 5) * textView.LineHeight));
                }
            };
            btnPercent.Click += (sender, e) =>
            {
                textView.Text = textView.Text + editText.Text + " ";
                editText.Text = btnPercent.Text + " ";
                if (textResult.Text != string.Empty)
                {
                    result = double.Parse(textResult.Text);
                }
                if (textView.LineCount > 5)
                {
                    textView.ScrollTo(0, ((textView.LineCount - 5) * textView.LineHeight));
                }
            };
            btnEqual.Click += (sender, e) =>
            {
                textView.Text = textView.Text + " " + editText.Text + " = " + textResult.Text + "\n----------------------------------------------------\n";
                editText.Text = "0";
                textResult.Text = "0";
            };
            #endregion

            #region btn Numbers
            btnZero.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnZero.Text : btnZero.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2)
                {
                    textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]);
                }
                else { textResult.Text = editText.Text; }
            };
            btnOne.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnOne.Text : btnOne.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnTwo.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnTwo.Text : btnTwo.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnThree.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnThree.Text : btnThree.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnFour.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnFour.Text : btnFour.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnFive.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnFive.Text : btnFive.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnSix.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnSix.Text : btnSix.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnSeven.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnSeven.Text : btnSeven.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnEight.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnEight.Text : btnEight.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnNine.Click += (sender, e) =>
            {
                editText.Text = (editText.Text != "0") ? editText.Text + btnNine.Text : btnNine.Text;
                string[] arr = editText.Text.Split(' ');

                if (textView.Text == string.Empty && arr.Length < 2)
                {
                    textResult.Text = editText.Text;
                }
                if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0]); }
                else { textResult.Text = editText.Text; }
            };
            btnDot.Click += (sender, e) =>
            {
                if (!editText.Text.Contains("."))
                {
                    editText.Text = (editText.Text != "0") ? editText.Text + btnDot.Text : btnDot.Text;
                    string[] arr = editText.Text.Split(' ');

                    if (textView.Text == string.Empty && arr.Length < 2)
                    {
                        textResult.Text = editText.Text;
                    }
                    //if (arr.Length == 2) { textResult.Text = Core.CalculatorHelper.Calculate(result, double.Parse(arr[1]), arr[0], delFlag); }
                    //else { textResult.Text = editText.Text; }
                }
            };
            #endregion
        }
    }
}

