﻿using Apple.Receipt.Models.Converters;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Apple.Receipt.Models
{
    public class AppleAppReceipt
    {
        public AppleAppReceipt()
        {
            PurchaseReceipts = new List<AppleInAppPurchaseReceipt>();
        }

        /// <summary>
        ///     Represents Receipt Type. Production / Sandbox.
        /// </summary>
        [JsonProperty("receipt_type")]
        public string ReceiptType { get; set; }

        /// <summary>
        ///     Represents iTunes Store item identifier
        /// </summary>
        [JsonProperty("adam_id")]
        public int? AdamId { get; set; }

        [JsonProperty("app_item")]
        public int? AppItem { get; set; }

        /// <summary>
        ///     The app’s version number.
        /// </summary>
        /// <remarks>
        ///     This corresponds to the value of CFBundleVersion (in iOS) or CFBundleShortVersionString (in macOS) in the
        ///     Info.plist.
        /// </remarks>
        [JsonProperty("application_version")]
        public string ApplicationVersion { get; set; }

        /// <summary>
        ///     The app’s bundle identifier.
        /// </summary>
        /// <remarks>
        ///     This corresponds to the value of CFBundleIdentifier in the Info.plist file.
        ///     Use this value to validate if the receipt was indeed generated for your app.
        /// </remarks>
        [JsonProperty("bundle_id")]
        public string BundleId { get; set; }

        [JsonProperty("download_id")]
        public int? DownloadId { get; set; }

        /// <summary>
        ///     The receipt for an in-app purchase.
        /// </summary>
        /// <remarks>
        ///     The value of this key is an array containing all in-app purchase receipts based on the in-app purchase transactions
        ///     present in the input base-64 receipt-data.
        /// </remarks>
        /// <remarks>
        ///     For receipts containing auto-renewable subscriptions, check the value of
        ///     the latest_receipt_info key to get the status of the most recent renewal.
        /// </remarks>
        /// <remarks>
        ///     The in-app purchase receipt for a consumable product is added to the receipt when the purchase is made. It is kept
        ///     in the receipt until your app finishes that transaction. After that point, it is removed from the receipt the next
        ///     time the receipt is updated - for example, when the user makes another purchase or if your app explicitly refreshes
        ///     the receipt.
        /// </remarks>
        /// <remarks>
        ///     The in-app purchase receipt for a non-consumable product, auto-renewable subscription, non-renewing
        ///     subscription, or free subscription remains in the receipt indefinitely.
        /// </remarks>
        /// <remarks>
        ///     An empty array is a valid receipt.
        /// </remarks>
        [JsonProperty("in_app")]
        public List<AppleInAppPurchaseReceipt>? PurchaseReceipts { get; set; }

        /// <summary>
        ///     The version of the app that was originally purchased.
        /// </summary>
        /// <remarks>
        ///     This corresponds to the value of CFBundleVersion (in iOS) or CFBundleShortVersionString (in macOS) in the
        ///     Info.plist file when the purchase was originally made.
        /// </remarks>
        /// <remarks>
        ///     In the sandbox environment, the value of this field is always “1.0”.
        /// </remarks>
        [JsonProperty("original_application_version")]
        public string OriginalApplicationVersion { get; set; }

        /// <summary>
        ///     For a transaction that restores a previous transaction, the date of the original transaction.
        /// </summary>
        /// <remarks>
        ///     In an auto-renewable subscription receipt, this indicates the beginning of the subscription period, even if the
        ///     subscription has been renewed.
        /// </remarks>
        [JsonProperty("original_purchase_date")]
        public string OriginalPurchaseDate { get; set; }

        /// <summary>
        ///     The same like <see cref="OriginalPurchaseDate" /> but in unix epoch milliseconds.
        /// </summary>
        [JsonProperty("original_purchase_date_ms")]
        public string OriginalPurchaseDateMs { get; set; }

        /// <summary>
        ///     The same like <see cref="OriginalPurchaseDate" /> but in PST timezone.
        /// </summary>
        [JsonProperty("original_purchase_date_pst")]
        public string OriginalPurchaseDatePst { get; set; }

        /// <summary>
        ///     The date when the app receipt was created.
        /// </summary>
        /// <remarks>
        ///     When validating a receipt, use this date to validate the receipt’s signature.
        /// </remarks>
        [JsonProperty("receipt_creation_date")]
        public string ReceiptCreationDate { get; set; }

        /// <summary>
        ///     The same like <see cref="ReceiptCreationDate" /> but in unix epoch milliseconds.
        /// </summary>
        [JsonProperty("receipt_creation_date_ms")]
        public string ReceiptCreationDateMs { get; set; }

        /// <summary>
        ///     The same like <see cref="ReceiptCreationDate" /> but in PST timezone.
        /// </summary>
        [JsonProperty("receipt_creation_date_pst")]
        public string ReceiptCreationDatePst { get; set; }

        /// <summary>
        ///     The date that the app receipt expires.
        /// </summary>
        /// <remarks>
        ///     This key is present only for apps purchased through the Volume Purchase Program. If this key is not present, the
        ///     receipt does not expire.
        /// </remarks>
        /// <remarks>
        ///     When validating a receipt, compare this date to the current date to determine whether the receipt is expired. Do
        ///     not try to use this date to calculate any other information, such as the time remaining before expiration.
        /// </remarks>
        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        /// <summary>
        ///     The same like <see cref="ExpirationDate" /> but in unix epoch milliseconds.
        /// </summary>
        [JsonProperty("expiration_date_ms")]
        public string ExpirationDateMs { get; set; }

        /// <summary>
        ///     The same like <see cref="ExpirationDate" /> but in PST timezone.
        /// </summary>
        [JsonProperty("expiration_date_pst")]
        public string ExpirationDatePst { get; set; }

        /// <summary>
        ///     The date of the request
        /// </summary>
        [JsonProperty("request_date")]
        public string RequestDate { get; set; }

        /// <summary>
        ///     The same like <see cref="RequestDate" /> but in unix epoch milliseconds.
        /// </summary>
        [JsonProperty("request_date_ms")]
        public string RequestDateMs { get; set; }

        /// <summary>
        ///     The same like <see cref="RequestDate" /> but in PST timezone.
        /// </summary>
        [JsonProperty("request_date_pst")]
        public string RequestDatePst { get; set; }

        /// <summary>
        ///     An arbitrary number that uniquely identifies a revision of your application.
        /// </summary>
        /// <remarks>
        ///     This key is not present for receipts created in the test environment. Use this value to identify the version of the
        ///     app that the customer bought.
        /// </remarks>
        [JsonProperty("version_external_identifier")]
        public int VersionExternalIdentifier { get; set; }

        #region Parsed dates objects

        public DateTime? ExpirationDateDt => DateTimeConverter.MillisecondsToDate(ExpirationDateMs);

        public DateTime? OriginalPurchaseDateDt => DateTimeConverter.MillisecondsToDate(OriginalPurchaseDateMs);

        public DateTime? ReceiptCreationDateDt => DateTimeConverter.MillisecondsToDate(ReceiptCreationDateMs);

        public DateTime? RequestDateDt => DateTimeConverter.MillisecondsToDate(RequestDateMs);

        #endregion
    }
}
