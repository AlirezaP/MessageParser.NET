using System;

namespace MessageParser.NET.Tools
{
    // BIM_ISO8583 http://www.codeproject.com/Tips/377446/BIM-ISO 
    // Here Added FildUsage And Some Changes

    public class ISO8583
    {

        int[] DEVarLen = new int[130];  
        int[] DEFixLen = new int[130];

       public enum FildUsage
        {
            Bitmap = 1
            ,
            PrimaryAccountNumber_PAN = 2
                ,
            ProcessingCode = 3
                ,
            AmountTransaction = 4
                ,
            AmountSettlement = 5
                ,
            AmountCardholderBilling = 6
                ,
            TransmissionDate_time = 7
                ,
            AmountCardholderBillingFee = 8
                ,
            ConversionRateSettlement = 9
                ,
            ConversionRateCardholderBilling = 10
                ,
            SystemTraceAuditNumber = 11
                ,
            TimeLocalTransaction_hhmmss = 12
                ,
            DateLocalTransaction_MMDD = 13
                ,
            DateExpiration = 14
                ,
            DateSettlement = 15
                ,
            DateConversion = 16
                ,
            DateCapture = 17
                ,
            MerchantType = 18
                ,
            AcquiringInstitutionCountryCode = 19
                ,
            PANExtendedCountryCode = 20
                ,
            ForwardingInstitutionCountryCode = 21
                ,
            PointOfServiceEntryMode = 22
                ,
            Application_PAN_Sequencenumber = 23
                ,
            FunctionCode_NetworkInternationalIdentifier_NII = 24
                ,
            PointOfServiceConditionCode = 25
               ,
            PointOfServiceCaptureCode = 26
                ,
            AuthorizingIdentifiCationResponseLength = 27
                ,
            AmountTransactionFee = 28
                ,
            AmountSettlementFee = 29
                ,
            AmountTransactionProcessingFee = 30
                ,
            AmountSettlementProcessingFee = 31
                ,
            AcquiringInstitutionIdentificationCode = 32
                ,
            ForwardingInstitutionIdentificationCode = 33
                ,
            PrimaryAccountNumberExtended = 34
                ,
            Track2data = 35
                ,
            Track3data = 36
                ,
            RetrievalReferenceNumber = 37
                ,
            AuthorizationIdentificationResponse = 38
                ,
            ResponseCode = 39
                ,
            ServiceRestrictionCode = 40
                ,
            CardAcceptorTerminalIdentification = 41
                ,
            CardAcceptorIdentificationCode = 42
                ,
            CardAcceptorName_Location = 43
                ,
            AdditionalResponseData = 44
                ,
            Track1data = 45
                ,
            AdditionalDataISO = 46
                ,
            AdditionalDataNational = 47
                ,
            AdditionalDataPrivate = 48
                ,
            CurrencyCodeTransaction = 49
                ,
            CurrencyCodeSettlement = 50
                ,
            CurrencyCodeCardholderBilling = 51
                ,
            PersonalIdentificationNumberData = 52
                ,
            SecurityRelatedControlInformation = 53
                ,
            AdditionalAmounts = 54
                ,
            ReservedISO = 55
                ,
            ReservedISO2 = 56
                ,
            ReservedNational = 57
                ,
            ReservedNational2 = 58
                ,
            ReservedNational3 = 59
                ,
            ReservedNational4 = 60
                ,
            ReservedPrivate = 61
                ,
            ReservedPrivate2 = 62
                ,
            ReservedPrivate3 = 63
                ,
            MessageAuthenticationCodeMAC = 64
                ,
            BitmapExtended = 65
                ,
            SettlementCode = 66
                ,
            ExtendedPaymentCode = 67
                ,
            ReceivingInstitutionCountryCode = 68
                ,
            SettlementInstitutionCountryCode = 69
                ,
            NetworkManagementInformationCode = 70
                ,
            MessageNumber = 71
                ,
            MessageNumberLast = 72
                ,
            DateAction_YYMMDD = 73
                ,
            CreditsNumber = 74
                ,
            CreditsReversalNumber = 75
                ,
            DebitsNumber = 76
                ,
            DebitsReversalNumber = 77
                ,
            TransferNumber = 78
                ,
            TransferReversalNumber = 79
                ,
            InquiriesNumber = 80
                ,
            AuthorizationsNumber = 81
                ,
            CreditsProcessingFeeAmount = 82
                ,
            CreditsTransactionFeeAmount = 83
                ,
            DebitsProcessingFeeAmount = 84
                ,
            DebitsTransactionFeeAmount = 85
                ,
            CreditsAmount = 86
                ,
            CreditsReversalAmount = 87
                ,
            DebitsAmount = 88
                ,
            DebitsReversalAmount = 89
                ,
            OriginalDataElements = 90
                ,
            FileUpdateCode = 91
                ,
            FileSecurityCode = 92
                ,
            ResponseIndicator = 93
                ,
            ServiceIndicator = 94
                ,
            ReplacementAmounts = 95
                ,
            MessageSecurityCode = 96
                ,
            AmountNetSettlement = 97
                ,
            Payee = 98
                ,
            SettlementInstitutionIdentificationCode = 99
                ,
            ReceivingInstitutionIdentificationCode = 100
                ,
            FileName = 101
                ,
            AccountIdentification1 = 102
                ,
            AccountIdentification2 = 103
                ,
            TransactionDescription = 104
                ,
            ReservedForISOUse = 105
                ,
            ReservedForISOUse2 = 106
                ,
            ReservedForISOUse3 = 107
                ,
            ReservedForISOUse4 = 108
                ,
            ReservedForISOUse5 = 109
                ,
            ReservedForISOUse6 = 110
                ,
            ReservedForISOUse7 = 111
                ,
            ReservedForNationalUse = 112
                ,
            ReservedForNationalUse2 = 113
                ,
            ReservedForNationalUse3 = 114
                ,
            ReservedForNationalUse4 = 115
                ,
            ReservedForNationalUse5 = 116
                ,
            ReservedForNationalUse6 = 117
                ,
            ReservedForNationalUse7 = 118
                ,
            ReservedForNationalUse8 = 119
                ,
            ReservedForPrivateUse = 120
                ,
            ReservedForPrivateUse2 = 121
                ,
            ReservedForPrivateUse3 = 122
                ,
            ReservedForPrivateUse4 = 123
                ,
            ReservedForPrivateUse5 = 124
                ,
            ReservedForPrivateUse6 = 125
                ,
            ReservedForPrivateUse7 = 126
                ,
            ReservedForPrivateUse8 = 127
                , MessageAuthenticationCode = 128
        }

        public ISO8583()
        {
            //Initialize BitMap Var Length Indicator
            DEVarLen[2] = 2; DEVarLen[32] = 2; DEVarLen[33] = 2; DEVarLen[34] = 2; DEVarLen[35] = 2; DEVarLen[36] = 3;
            DEVarLen[44] = 2; DEVarLen[45] = 2; DEVarLen[46] = 3; DEVarLen[47] = 3; DEVarLen[48] = 3; DEVarLen[54] = 3;
            DEVarLen[55] = 3; DEVarLen[56] = 3; DEVarLen[57] = 3; DEVarLen[58] = 3; DEVarLen[59] = 3;
            DEVarLen[60] = 1; DEVarLen[61] = 3; DEVarLen[62] = 3; DEVarLen[63] = 3; DEVarLen[72] = 3; DEVarLen[99] = 2;
            DEVarLen[100] = 2; DEVarLen[102] = 2; DEVarLen[103] = 2; DEVarLen[104] = 3; DEVarLen[105] = 3;
            DEVarLen[106] = 3; DEVarLen[107] = 3; DEVarLen[108] = 3; DEVarLen[109] = 3; DEVarLen[110] = 3;
            DEVarLen[111] = 3; DEVarLen[112] = 3; DEVarLen[113] = 2; DEVarLen[114] = 3; DEVarLen[115] = 3;
            DEVarLen[116] = 3; DEVarLen[117] = 3; DEVarLen[118] = 3; DEVarLen[119] = 3; DEVarLen[120] = 3; DEVarLen[121] = 3;
            DEVarLen[122] = 3; DEVarLen[123] = 3; DEVarLen[124] = 3; DEVarLen[125] = 2; DEVarLen[126] = 1; DEVarLen[127] = 3;

            // "-" means not numeric.

            DEFixLen[0] = 16; DEFixLen[1] = 16; DEFixLen[3] = 6; DEFixLen[4] = 12;
            DEFixLen[5] = 12; DEFixLen[6] = 12; DEFixLen[7] = 10; DEFixLen[8] = 8;
            DEFixLen[9] = 8; DEFixLen[10] = 8; DEFixLen[11] = 6; DEFixLen[12] = 6;
            DEFixLen[13] = 4; DEFixLen[14] = 4; DEFixLen[15] = 4; DEFixLen[16] = 4;
            DEFixLen[17] = 4; DEFixLen[18] = 4; DEFixLen[19] = 3; DEFixLen[20] = 3;
            DEFixLen[21] = 3; DEFixLen[22] = 3; DEFixLen[23] = 3; DEFixLen[24] = 3;
            DEFixLen[25] = 2; DEFixLen[26] = 2; DEFixLen[27] = 1; DEFixLen[28] = 8;
            DEFixLen[29] = 8; DEFixLen[30] = 8; DEFixLen[31] = 8; DEFixLen[37] = -12;
            DEFixLen[38] = -6; DEFixLen[39] = -2; DEFixLen[40] = -3; DEFixLen[41] = -8;
            DEFixLen[42] = -15; DEFixLen[43] = -40; DEFixLen[49] = -3; DEFixLen[50] = -3;
            DEFixLen[51] = -3; DEFixLen[52] = -16; DEFixLen[53] = 18; DEFixLen[64] = -4;
            DEFixLen[65] = -16; DEFixLen[66] = 1; DEFixLen[67] = 2; DEFixLen[68] = 3;
            DEFixLen[69] = 3; DEFixLen[70] = 3; DEFixLen[71] = 4; DEFixLen[73] = 6;
            DEFixLen[74] = 10; DEFixLen[75] = 10; DEFixLen[76] = 10; DEFixLen[77] = 10;
            DEFixLen[78] = 10; DEFixLen[79] = 10; DEFixLen[80] = 10; DEFixLen[81] = 10;
            DEFixLen[82] = 12; DEFixLen[83] = 12; DEFixLen[84] = 12; DEFixLen[85] = 12;
            DEFixLen[86] = 15; DEFixLen[87] = 15; DEFixLen[88] = 15; DEFixLen[89] = 15;
            DEFixLen[90] = 42; DEFixLen[91] = -1; DEFixLen[92] = 2; DEFixLen[93] = 5;
            DEFixLen[94] = -7; DEFixLen[95] = -42; DEFixLen[96] = -8; DEFixLen[97] = 16;
            DEFixLen[98] = -25; DEFixLen[101] = -17; DEFixLen[128] = -16;

        }
        public string Build(string[] DE, string MTI)
        {
            string newISO = MTI;

            
            string newDE1 = "";
            for (int I = 2; I <= 64; I++) { if (DE[I] != null) { newDE1 += "1"; } else { newDE1 += "0"; } }

            
            string newDE2 = "";
            for (int I = 65; I <= 128; I++) { if (DE[I] != null) { newDE2 += "1"; } else { newDE2 += "0"; } }

            if (newDE2 == "0000000000000000000000000000000000000000000000000000000000000000")
            { newDE1 = "0" + newDE1; }
            else { newDE1 = "1" + newDE1; }



            string DE1Hex = String.Format("{0:X1}", Convert.ToInt64(newDE1, 2));
            DE1Hex = DE1Hex.PadLeft(16, '0'); //Pad-Left
            DE[0] = DE1Hex;

            string DE2Hex = String.Format("{0:X1}", Convert.ToInt64(newDE2, 2));
            DE2Hex = DE2Hex.PadLeft(16, '0'); //Pad-Left
            DE[1] = DE2Hex;

            if (DE2Hex == "0000000000000000") DE[1] = null;

          

            for (int I = 0; I <= 128; I++)
            {
                if (DE[I] != null)
                {
                    if (DEVarLen[I] < 1)
                    {

                        if (DEFixLen[I] < 0)
                        {
                            string BMPadded = DE[I].PadRight(Math.Abs(DEFixLen[I]), ' ');
                            string sBM = BMPadded.Substring(0, Math.Abs(DEFixLen[I]));

                            newISO += sBM;
                        }
                        else
                        {
                            string BMPadded = DE[I].PadLeft(DEFixLen[I], '0');
                            string sBM = BMPadded.Substring(BMPadded.Length - Math.Abs(DEFixLen[I]), Math.Abs(DEFixLen[I]));
                            newISO += sBM;
                        }   
                    }
                    else
                    {
                        string li = DE[I].Length.ToString();
                        string paddedli = li.PadLeft(DEVarLen[I], '0');
                        newISO += (paddedli + DE[I]);
                    }
                }
            }

            return newISO;


        }
        public string[] Parse(string ISOmsg)
        {
            string[] DE = new string[130];
            
            string de1Binary = "";
            string de2Binary = "";
            int FieldNo;


            int myPos;
            int myLenght;
            int len;
            //Get MTI
            myPos = 0;
            myLenght = 4;
            string MTI = ISOmsg.Substring(myPos, myLenght);


            //========BM 129 is the MTI============
            FieldNo = 129;
            

            DE[FieldNo] = MTI;
            //========================================
            //Get BitMap 1a
            myPos += myLenght;
            myLenght = 16;
            DE[0] = ISOmsg.Substring(myPos, myLenght);

            //Convert BM0 to Binary


            de1Binary = DEtoBinary(DE[0]);
            

            //BitMap #1

            FieldNo = 1;
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght;
                myLenght = 16;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
                de2Binary = DEtoBinary(DE[FieldNo]);
            }

            //------------BM2--------------
            FieldNo = 2;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, 2));
                myPos += 2;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM3--------------
            FieldNo = 3;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { 
                myPos += myLenght;
                myLenght = 6;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); 
            }


            //------------BM4--------------
            FieldNo = 4;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            {
                myPos += myLenght; 
                myLenght = 12;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM5--------------
            FieldNo = 5;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght;
                myLenght = 12; 
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }


            //------------BM6--------------
            FieldNo = 6;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { myPos += myLenght;
                myLenght = 12;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM7--------------
            FieldNo = 7;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { myPos += myLenght;
                myLenght = 10;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); 
            }

            //------------BM8--------------
            FieldNo = 8;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { myPos += myLenght; 
                myLenght = 8;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM9--------------
            FieldNo = 9;
           
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { 
                myPos += myLenght;
                myLenght = 8; 
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM 10--------------
            FieldNo = 10;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            {
                myPos += myLenght; 
                myLenght = 8;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM 11--------------
            FieldNo = 11;
           
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { 
                myPos += myLenght;
                myLenght = 6; 
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM 12--------------
            FieldNo = 12;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; 
                myLenght = 6;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM 13--------------
            FieldNo = 13;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { myPos += myLenght;
                myLenght = 4;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM 14--------------
            FieldNo = 14;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght;
                myLenght = 4; 
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //------------BM 15--------------
            FieldNo = 15;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; myLenght = 4; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }

            //------------BM 16--------------
            FieldNo = 16;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; myLenght = 4; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }

            //------------BM 17--------------
            FieldNo = 17;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; myLenght = 4; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }

            //------------BM 18--------------
            FieldNo = 18;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; myLenght = 4; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------BM 19--------------
            FieldNo = 19;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }

            //------------BM 20--------------
            FieldNo = 20;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------BM 21--------------
            FieldNo = 21;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { 
                myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------BM 22--------------
            FieldNo = 22;
           
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            {
                myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 23;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 24;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            {
                myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 25;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            { 
                myPos += myLenght; myLenght = 2; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 26;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; myLenght = 2; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 27;
           
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; myLenght = 1; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 28;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            {
                myPos += myLenght; myLenght = 8; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 29;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; myLenght = 8; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 30;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; myLenght = 8; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 31;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            { 
                myPos += myLenght; myLenght = 8; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 32;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, 2));
                myPos += 2;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //--------------------------
            FieldNo = 33;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, 2));
                myPos += 2;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 34;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, 2));
                myPos += 2;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 35;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len));
                myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 36;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len));
                myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 37;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 12; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 38;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 6; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 39;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 2; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 40;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 41;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") 
            {
                myPos += myLenght;
                myLenght = 8;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 42;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 15; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 43;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 40; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }

            //--------------------------
            FieldNo = 44;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len));
                myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 45;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len));
                myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 46;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len));
                myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 47;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len));
                myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 48;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len));
                myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }


            //--------------------------
            FieldNo = 49;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { 
                myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 50;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 51;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 52;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 16; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 53;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 18; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 54;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 55;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 56;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 57;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 58;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 59;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 60;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 1;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 61;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 62;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 63;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            //--------------------------
            FieldNo = 64;
            
            if (de1Binary.Substring(FieldNo - 1, 1) == "1") { myPos += myLenght; myLenght = 4; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }

            /*
            for (int I = 0; I <= 64; I++)
            {
                if (BM[I] != null)

                { Console.WriteLine("BM" + I + ": " + BM[I] + " = " + BMname[I]); }
            }
            */

            //===CHECK POINT FOR BM# 65 to 128============
            if (de2Binary == "") return DE; ///<----IF DATA ELEMENT <= 64
            if (de2Binary == "0000000000000000000000000000000000000000000000000000000000000000") return DE;
            //============================================

            //--------------------------
            int comp = 64;
            FieldNo = 65;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 16; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 66;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 1; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 67;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 2; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 68;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 69;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 70;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 3; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 71;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 4; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //-------------------------------------------------
            FieldNo = 72;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //--------------------------
            FieldNo = 73;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 6; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //--------------------------
            FieldNo = 74;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 75;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 76;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 77;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 78;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 79;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 80;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 81;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 10; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //-----------------------------
            FieldNo = 82;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 12; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 83;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 12; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 84;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 12; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 85;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 12; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 86;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 15; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 87;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 15; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 88;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 15; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 89;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 15; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            FieldNo = 90;
            

            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 42; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 91;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 1; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 92;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 2; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 93;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 5; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 94;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 7; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 95;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 42; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 96;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 8; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 97;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 16; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //------------------------------
            FieldNo = 98;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 25; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //-------------------------------------------------
            FieldNo = 99;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 100;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //------------------------------
            FieldNo = 101;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 17; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }

            //-------------------------------------------------
            FieldNo = 102;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 103;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //----------------------------------
            FieldNo = 104;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 105;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 106;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 107;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 108;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 109;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 110;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 111;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 112;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //----------------------------
            FieldNo = 113;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //-------------------------
            FieldNo = 114;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 115;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 116;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 117;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 118;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 119;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 120;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 121;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 122;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            FieldNo = 123;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }

            FieldNo = 124;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //---------------------------------
            FieldNo = 125;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 2;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //----------------------------------
            FieldNo = 126;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 1;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //-----------------------------------
            FieldNo = 127;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1")
            {
                myPos += myLenght; len = 3;
                myLenght = Convert.ToInt16(ISOmsg.Substring(myPos, len)); myPos += len;
                DE[FieldNo] = ISOmsg.Substring(myPos, myLenght);
            }
            //------------------------------
            FieldNo = 128;
            
            if (de2Binary.Substring(FieldNo - comp - 1, 1) == "1") { myPos += myLenght; myLenght = 4; DE[FieldNo] = ISOmsg.Substring(myPos, myLenght); }
            //-------------------------------------------------



            //==========================================
            return DE;
            //==========================================




        }
        //==========================================================
        private string DEtoBinary(string HexDE)
        {
            string deBinary = "";
            for (int I = 0; I <= 15; I++)
            {
             //   deBinary = deBinary + Hex2Binary(HexDE.Substring(I, 1));
                deBinary = deBinary + Hex2BinaryAP(HexDE.Substring(I, 1));
            }

            return deBinary;

        }

        private string Hex2BinaryAP(string hexOutput)
        {
            string res = "";
            int input = Convert.ToInt32(hexOutput, 16); ;

            while (input > 0)
            {
                res = (input % 2).ToString() + res;
                input /= 2;
            }

            return res.PadLeft(4, '0');
        }

        //private string Hex2Binary(string DE)
        //{

        //    string myBinary = "";
        //    switch (DE)
        //    {
        //        case "0":
        //            myBinary = "0000";
        //            break;

        //        case "1":
        //            myBinary = "0001";
        //            break;

        //        case "2":
        //            myBinary = "0010";
        //            break;

        //        case "3":
        //            myBinary = "0011";
        //            break;

        //        case "4":
        //            myBinary = "0100";
        //            break;

        //        case "5":
        //            myBinary = "0101";
        //            break;

        //        case "6":
        //            myBinary = "0110";
        //            break;

        //        case "7":
        //            myBinary = "0111";
        //            break;

        //        case "8":
        //            myBinary = "1000";
        //            break;

        //        case "9":
        //            myBinary = "1001";
        //            break;

        //        case "A":
        //            myBinary = "1010";
        //            break;

        //        case "B":
        //            myBinary = "1011";
        //            break;

        //        case "C":
        //            myBinary = "1100";
        //            break;

        //        case "D":
        //            myBinary = "1101";
        //            break;

        //        case "E":
        //            myBinary = "1110";
        //            break;

        //        case "F":
        //            myBinary = "1111";
        //            break;

        //    }


        //    return myBinary;

        //}



    }
}
