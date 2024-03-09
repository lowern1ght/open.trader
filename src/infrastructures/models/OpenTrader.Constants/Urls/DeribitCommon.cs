namespace OpenTrader.Constants.Urls;

public class DeribitCommon
{
    public const string UserTrades = "/private/get_user_trades_by_instrument";
    public const string SummaryInstrument = "/public/get_book_summary_by_instrument";
        
    public class Order
    {
        public const string Buy = "/private/buy";
        public const string Sell = "/private/sell";
        public const string Cancel = "/private/cancel";
        public const string EditByLabel = "/private/edit_by_label";
        public const string OrdersByLabel = "/private/get_open_orders_by_label";
        public const string CancelByInstrument = "/private/cancel_all_by_instrument";
        public const string ListByInstrument = "/private/get_open_orders_by_instrument";
        public const string HistoryByInstrument = "/private/get_order_history_by_currency";
    }
}