﻿using System;
using Newtonsoft.Json;

namespace BitstampTradeBot.Trader.Models.Exchange
{
    public class BitstampTransaction
    {
        // Date and time
        [JsonProperty(PropertyName = "datetime")]
        public DateTime Timestamp { get; set; }

        // Transaction ID
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        // Transaction type: 0 - deposit; 1 - withdrawal; 2 - market trade; 14 - sub account transfer
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

        // USD amount
        [JsonProperty(PropertyName = "usd")]
        public decimal Usd { get; set; }

        // EUR amount
        [JsonProperty(PropertyName = "eur")]
        public decimal Eur { get; set; }

        // BTC amount
        [JsonProperty(PropertyName = "btc")]
        public decimal Btc { get; set; }

        // XRP amount
        [JsonProperty(PropertyName = "xrp")]
        public decimal Xrp { get; set; }

        // LTC amount
        [JsonProperty(PropertyName = "ltc")]
        public decimal Ltc { get; set; }

        // ETH amount
        [JsonProperty(PropertyName = "eth")]
        public decimal Eth { get; set; }

        // BCH amount
        [JsonProperty(PropertyName = "bch")]
        public decimal Bch { get; set; }

        [JsonIgnore]
        public BitstampCurrencyCode CurrencySold
        {
            get
            {
                if (Usd < 0) return BitstampCurrencyCode.Usd;
                if (Eur < 0) return BitstampCurrencyCode.Eur;
                if (Btc < 0) return BitstampCurrencyCode.Btc;
                if (Xrp < 0) return BitstampCurrencyCode.Xrp;
                if (Ltc < 0) return BitstampCurrencyCode.Ltc;
                if (Eth < 0) return BitstampCurrencyCode.Eth;
                if (Bch < 0) return BitstampCurrencyCode.Bch;

                throw new Exception("No sell currency found!");
            }
        }

        [JsonIgnore]
        public decimal AmountSold
        {
            get
            {
                if (Usd < 0) return Usd;
                if (Eur < 0) return Eur;
                if (Btc < 0) return Btc;
                if (Xrp < 0) return Xrp;
                if (Ltc < 0) return Ltc;
                if (Eth < 0) return Eth;
                if (Bch < 0) return Bch;

                throw new Exception("No sell amount found!");
            }
        }

        [JsonIgnore]
        public BitstampCurrencyCode CurrencyBought
        {
            get
            {
                if (Usd > 0) return BitstampCurrencyCode.Usd;
                if (Eur > 0) return BitstampCurrencyCode.Eur;
                if (Btc > 0) return BitstampCurrencyCode.Btc;
                if (Xrp > 0) return BitstampCurrencyCode.Xrp;
                if (Ltc > 0) return BitstampCurrencyCode.Ltc;
                if (Eth > 0) return BitstampCurrencyCode.Eth;
                if (Bch > 0) return BitstampCurrencyCode.Bch;

                throw new Exception("No buy currency found!");
            }
        }

        [JsonIgnore]
        public decimal AmountBought
        {
            get
            {
                if (Usd > 0) return Usd;
                if (Eur > 0) return Eur;
                if (Btc > 0) return Btc;
                if (Xrp > 0) return Xrp;
                if (Ltc > 0) return Ltc;
                if (Eth > 0) return Eth;
                if (Bch > 0) return Bch;

                throw new Exception("No buy amount found!");
            }
        }

        // Exchange rate
        [JsonProperty(PropertyName = "btc_usd")]
        public decimal ExchangeRateBtcUsd { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "btc_eur")]
        public decimal ExchangeRateBtcEur { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "eur_usd")]
        public decimal ExchangeRateEurUsd { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "xrp_usd")]
        public decimal ExchangeRateXrpUsd { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "xrp_eur")]
        public decimal ExchangeRateXrpEur { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "xrp_btc")]
        public decimal ExchangeRateXrpBtc { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "ltc_usd")]
        public decimal ExchangeRateLtcUsd { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "ltc_eur")]
        public decimal ExchangeRateLtcEur { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "ltc_btc")]
        public decimal ExchangeRateLtcBtc { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "eth_usd")]
        public decimal ExchangeRateEthUsd { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "eth_eur")]
        public decimal ExchangeRateEthEur { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "eth_btc")]
        public decimal ExchangeRateEthBtc { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "bch_usd")]
        public decimal ExchangeRateBchUsd { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "bch_eur")]
        public decimal ExchangeRateBchEur { get; set; }

        // Exchange rate
        [JsonProperty(PropertyName = "bch_btc")]
        public decimal ExchangeRateBchBtc { get; set; }

        public decimal ExchangeRate
        {
            get
            {
                if (ExchangeRateBtcUsd > 0) return ExchangeRateBtcUsd;
                if (ExchangeRateBtcEur > 0) return ExchangeRateBtcEur;
                if (ExchangeRateEurUsd > 0) return ExchangeRateEurUsd;
                if (ExchangeRateXrpUsd > 0) return ExchangeRateXrpUsd;
                if (ExchangeRateXrpEur > 0) return ExchangeRateXrpEur;
                if (ExchangeRateXrpBtc > 0) return ExchangeRateXrpBtc;
                if (ExchangeRateLtcUsd > 0) return ExchangeRateLtcUsd;
                if (ExchangeRateLtcEur > 0) return ExchangeRateLtcEur;
                if (ExchangeRateLtcBtc > 0) return ExchangeRateLtcBtc;
                if (ExchangeRateEthUsd > 0) return ExchangeRateEthUsd;
                if (ExchangeRateEthEur > 0) return ExchangeRateEthEur;
                if (ExchangeRateEthBtc > 0) return ExchangeRateEthBtc;
                if (ExchangeRateBchUsd > 0) return ExchangeRateBchUsd;
                if (ExchangeRateBchEur > 0) return ExchangeRateBchEur;
                if (ExchangeRateBchBtc > 0) return ExchangeRateBchBtc;

                throw new Exception("No exchange rate found!");
            }
        }

        // Transaction fee
        [JsonProperty(PropertyName = "fee")]
        public decimal Fee { get; set; }

        // Executed order ID.
        [JsonProperty(PropertyName = "order_id")]
        public long OrderId { get; set; }
    }
}