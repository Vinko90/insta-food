/*
    Description: StaticDetails class
    
    Author: WarOfDevil          Date: 06-03-2020
*/

namespace InstaFood.Utility
{
    /// <summary>
    /// Static class declaring user roles
    /// </summary>
    public static class StaticDetails
    {
        #region User

        /// <summary>
        /// Manager user role name
        /// </summary>
        public const string ManagerRole = "Manager";

        /// <summary>
        /// Front desk user role name
        /// </summary>
        public const string FrontDeskRole = "Front";

        /// <summary>
        /// Kitchen user role name
        /// </summary>
        public const string KitchenRole = "Kitchen";

        /// <summary>
        /// Customer user role name
        /// </summary>
        public const string CustomerRole = "Customer";

        #endregion

        #region Shopping Cart

        /// <summary>
        /// Shopping Cart
        /// </summary>
        public const string ShoppingCart = "ShoppingCart";

        #endregion

        #region Order Status

        /// <summary>
        /// Status for order "Submitted"
        /// </summary>
        public const string StatusSubmitted = "Submitted";

        /// <summary>
        /// Status for order "In Process"
        /// </summary>
        public const string StatusInProcess = "Being Prepared";

        /// <summary>
        /// Status for order "Ready for Pickup"
        /// </summary>
        public const string StatusReady = "Ready for Pickup";

        /// <summary>
        /// Status for order "Completed"
        /// </summary>
        public const string StatusCompleted = "Completed";

        /// <summary>
        /// Status for order "Cancelled"
        /// </summary>
        public const string StatusCancelled = "Cancelled";

        /// <summary>
        /// Status for order "Refounded"
        /// </summary>
        public const string StatusRefunded = "Refunded";

        #endregion

        #region Payment Status

        /// <summary>
        /// Payment Status "Pending"
        /// </summary>
        public const string PaymentStatusPending = "Pending";

        /// <summary>
        /// Payment Status "Approved"
        /// </summary>
        public const string PaymentStatusApproved = "Approved";

        /// <summary>
        /// Payment Status "Rejected"
        /// </summary>
        public const string PaymentStatusRejected = "Rejected";

        #endregion
    }
}
