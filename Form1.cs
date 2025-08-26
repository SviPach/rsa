using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using static System.Security.Cryptography.RandomNumberGenerator;
using static RSA.Functions;

namespace RSA
{
    public partial class Form1 : Form
    {
        class GenKeysInfo
        {
            public static BigInteger P;
            public static BigInteger Q;
            public static BigInteger N;
            public static BigInteger fN;
            public static BigInteger E = 65537;
            public static BigInteger D;
            
            private void CalculateN() { N = P * Q; }
            private void CalculateFn() { fN = (P - 1) * (Q - 1); }
            private void CalculateD() { D = ModInverse(E, fN); }
            
            public BigInteger GetP() { return P; }
            public BigInteger GetQ() { return Q; }
            public BigInteger GetN() { return N; }
            public BigInteger GetFn() { return fN; }
            public BigInteger GetE() { return E; }
            public BigInteger GetD() { return D; }
            
            public GenKeysInfo(BigInteger p, BigInteger q)
            {
                P = p;
                Q = q;
                CalculateN();
                CalculateFn();
                while (GCD(fN, E) != 1)
                {
                    E += 2;
                }
                CalculateD();
            }
        }

        private GenKeysInfo GeneratedKeysInfo = new GenKeysInfo(0, 0);
        public Form1()
        {
            InitializeComponent();
            button_text_encrypt.Enabled = false;
            button_text_decrypt.Enabled = false;
            button_keys_change.Enabled = false;
        }
        
        private void button_keys_generate_Click(object sender, EventArgs e)
        {
            BigInteger p = GenerateRandomBigInteger(1000000000000, 9999999999999);
            while (p < 1000000000000 || p > 9999999999999 || !IsPrime(p))
            {
                char[] pArray = p.ToString().ToCharArray();
                if (pArray[12] == '0' || pArray[12] == '2' || pArray[12] == '4' || pArray[12] == '5' || pArray[12] == '6' ||
                    pArray[12] == '8')
                {
                    p =  GenerateRandomBigInteger(1000000000000, 9999999999999);
                    continue;
                }
                p = GenerateRandomBigInteger(1000000000000, 9999999999999);
            }
            
            BigInteger q = GenerateRandomBigInteger(1000000000000, 9999999999999);
            while (q < 1000000000000 || q > 9999999999999 || !IsPrime(q))
            {
                char[] qArray = q.ToString().ToCharArray();
                if (qArray[12] == '0' || qArray[12] == '2' || qArray[12] == '4' || qArray[12] == '5' || qArray[12] == '6' ||
                    qArray[12] == '8')
                {
                    q = GenerateRandomBigInteger(1000000000000, 9999999999999);
                    continue;
                }
                q = GenerateRandomBigInteger(1000000000000, 9999999999999);
            }
            
            GeneratedKeysInfo = new GenKeysInfo(p, q);
            
            textBox_key_n.Text = GeneratedKeysInfo.GetN().ToString();
            textBox_key_e.Text = GeneratedKeysInfo.GetE().ToString();
            textBox_key_d.Text = GeneratedKeysInfo.GetD().ToString();
            
            MessageBox.Show($"P: {GeneratedKeysInfo.GetP().ToString()}" +
                            $"\nQ: {GeneratedKeysInfo.GetQ().ToString()}" +
                            $"\nfn: {GeneratedKeysInfo.GetFn().ToString()}" +
                            $"\nN: {GeneratedKeysInfo.GetN().ToString()}" +
                            $"\nE: {GeneratedKeysInfo.GetE().ToString()}" +
                            $"\nD: {GeneratedKeysInfo.GetD().ToString()}");

            textBox_key_n.ReadOnly = true;
            textBox_key_e.ReadOnly = true;
            textBox_key_d.ReadOnly = true;
            button_keys_generate.Enabled = false;
            button_keys_check.Enabled = false;
            
            button_text_encrypt.Enabled = true;
            button_text_decrypt.Enabled = true;
            button_keys_change.Enabled = true;
        }

        private void button_keys_change_Click(object sender, EventArgs e)
        {
            textBox_key_n.ReadOnly = false;
            textBox_key_e.ReadOnly = false;
            textBox_key_d.ReadOnly = false;
            button_keys_generate.Enabled = true;
            button_keys_check.Enabled = true;
            
            button_text_encrypt.Enabled = false;
            button_text_decrypt.Enabled = false;
            button_keys_change.Enabled = false;
        }

        private void button_text_encrypt_Click(object sender, EventArgs e)
        {
            List<string> textArray = new List<string>{};

            string filteredText = ConvertToAscii(textBox_text_input.Text);
            
            for(int i = 0; i < textBox_text_input.Text.Length; i += + 5)
            {
                if (i+5 > textBox_text_input.Text.Length - 1)
                {
                    textArray.Add(filteredText.Substring(i, textBox_text_input.Text.Length - i));
                }
                else
                {
                    textArray.Add(filteredText.Substring(i, 5));
                }
            }

            BigInteger E = BigInteger.Parse(textBox_key_e.Text);
            BigInteger N = BigInteger.Parse(textBox_key_n.Text);
            
            string textEncrypted = "";
            foreach (string str in textArray)
            {
                textEncrypted += TextEncrypt(BigInteger.Parse(TextToSuperNumber(str)), N, E) + "\n";
            }
            
            textBox_text_output.Text = textEncrypted;
        }

        private void button_text_decrypt_Click(object sender, EventArgs e)
        {
            List<string> textArray = new List<string>{};

            textArray = textBox_text_input.Text.Split('\n').ToList();

            if (textArray[textArray.Count - 1] == "")
            {
                textArray.RemoveAt(textArray.Count - 1);
            }

            BigInteger N = BigInteger.Parse(textBox_key_n.Text);
            BigInteger D = BigInteger.Parse(textBox_key_d.Text);

            List<string> textArrayDecrypted = new List<string>();
            foreach (string str in textArray)
            {
                textArrayDecrypted.Add(TextDecrypt(BigInteger.Parse(str), N, D));
            }

            string textDecrypted = "";

            foreach (string str in textArrayDecrypted)
            {
                textDecrypted += SuperNumberToText(str);
            }
            
            textBox_text_output.Text = textDecrypted;
        }

        private void button_keys_check_Click(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(textBox_key_n.Text, out BigInteger N))
            {
                if (BigInteger.TryParse(textBox_key_e.Text, out BigInteger E))
                {
                    if (IsPrime(E))
                    {
                        button_text_encrypt.Enabled = true;
                    }
                    
                }
                if (BigInteger.TryParse(textBox_key_d.Text, out BigInteger D))
                {
                    button_text_decrypt.Enabled = true;
                }
                
            }

            if (button_text_encrypt.Enabled == false && button_text_decrypt.Enabled == false)
            {
                MessageBox.Show("Not a valid keys!");
                return;
            }
            
            textBox_key_n.ReadOnly = true;
            textBox_key_e.ReadOnly = true;
            textBox_key_d.ReadOnly = true;
            button_keys_generate.Enabled = false;
            button_keys_check.Enabled = false;
            
            button_keys_change.Enabled = true;
        }
        
        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_generatedKeysInfo_Click(object sender, EventArgs e)
        {
            if (GeneratedKeysInfo.GetP() == 0 && GeneratedKeysInfo.GetQ() == 0)
            {
                MessageBox.Show("Generate new keys first!");
                return;
            }
            GeneratedKeysInfoForm Form2 = new GeneratedKeysInfoForm(
                GeneratedKeysInfo.GetP(), GeneratedKeysInfo.GetQ(),
                GeneratedKeysInfo.GetN(), GeneratedKeysInfo.GetFn(),
                GeneratedKeysInfo.GetE(), GeneratedKeysInfo.GetD());
            Form2.Show();
        }
    }
}