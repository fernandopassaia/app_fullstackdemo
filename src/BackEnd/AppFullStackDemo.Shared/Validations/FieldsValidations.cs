namespace AppFullStackDemo.Shared.Validations
{
    public static class FieldsValidations
    {
        #region ValidateCountryRegistryNumber (CPF/CNPJ)

        public static bool ValidateCountryRegistryNumber(string Value)
        {
            string valor = Value.Replace(".", "");
            valor = valor.Replace("-", "");
            valor = valor.Replace(",", "");
            valor = valor.Replace("/", "");
            valor = valor.Replace("\\", "");

            if (valor.Length != 11 && valor.Length != 14)
                return false;

            #region Validacao CPF

            if (valor.Length == 11)
            {
                bool igual = true;
                for (int i = 1; i < 11 && igual; i++)
                    if (valor[i] != valor[0])
                        igual = false;
                if (igual || valor == "12345678909")
                    return false;
                int[] numeros = new int[11];
                for (int i = 0; i < 11; i++)

                    numeros[i] = int.Parse(

                      valor[i].ToString());

                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += (10 - i) * numeros[i];
                int resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0)

                        return false;
                }
                else if (numeros[9] != 11 - resultado)
                    return false;

                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += (11 - i) * numeros[i];
                resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                        return false;
                }
                else
                    if (numeros[10] != 11 - resultado)
                    return false;
                return true;
            }

            #endregion Validacao CPF

            #region Validacao CNPJ

            if (valor.Length == 14)
            {
                string CNPJ = valor.Replace(".", "");
                CNPJ = CNPJ.Replace("/", "");
                CNPJ = CNPJ.Replace("-", "");

                int[] digitos, soma, resultado;
                int nrDig;
                string ftmt;
                bool[] CNPJOk;

                ftmt = "6543298765432";
                digitos = new int[14];
                soma = new int[2];
                soma[0] = 0;
                soma[1] = 0;
                resultado = new int[2];
                resultado[0] = 0;
                resultado[1] = 0;
                CNPJOk = new bool[2];
                CNPJOk[0] = false;
                CNPJOk[1] = false;

                try
                {
                    for (nrDig = 0; nrDig < 14; nrDig++)
                    {
                        digitos[nrDig] = int.Parse(
                            CNPJ.Substring(nrDig, 1));
                        if (nrDig <= 11)
                            soma[0] += (digitos[nrDig] *
                              int.Parse(ftmt.Substring(
                              nrDig + 1, 1)));
                        if (nrDig <= 12)
                            soma[1] += (digitos[nrDig] *
                              int.Parse(ftmt.Substring(
                              nrDig, 1)));
                    }

                    for (nrDig = 0; nrDig < 2; nrDig++)
                    {
                        resultado[nrDig] = (soma[nrDig] % 11);
                        if ((resultado[nrDig] == 0) || (
                             resultado[nrDig] == 1))
                            CNPJOk[nrDig] = (
                            digitos[12 + nrDig] == 0);
                        else
                            CNPJOk[nrDig] = (
                            digitos[12 + nrDig] == (
                            11 - resultado[nrDig]));
                    }
                    return (CNPJOk[0] && CNPJOk[1]);
                }
                catch
                {
                    return false;
                }
            }

            #endregion Validacao CNPJ

            return false;
        }

        #endregion ValidateCountryRegistryNumber (CPF/CNPJ)
    }
}