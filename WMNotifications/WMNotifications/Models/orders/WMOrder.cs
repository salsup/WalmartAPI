using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMNotifications.Models.orders
{

    public class WMOrder
    {
        public Meta meta { get; set; }
        public Elements elements { get; set; }
    }

    public class Meta
    {
        public int totalCount { get; set; }
        public int limit { get; set; }
        public object nextCursor { get; set; }
    }

    public class Elements
    {
        public Order[] order { get; set; }
    }

    public class Order
    {
        public string purchaseOrderId { get; set; }
        public string customerOrderId { get; set; }
        public string customerEmailId { get; set; }
        public long orderDate { get; set; }
        public Shippinginfo shippingInfo { get; set; }
        public Orderlines orderLines { get; set; }
    }

    public class Shippinginfo
    {
        public string phone { get; set; }
        public long estimatedDeliveryDate { get; set; }
        public string methodCode { get; set; }
        public Postaladdress postalAddress { get; set; }
    }

    public class Postaladdress
    {
        public string name { get; set; }
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string addressType { get; set; }
    }

    public class Orderlines
    {
        public Orderline[] orderLine { get; set; }
    }

    public class Orderline
    {
        public string lineNumber { get; set; }
        public Item item { get; set; }
        public Charges charges { get; set; }
        public Orderlinequantity orderLineQuantity { get; set; }
        public long statusDate { get; set; }
        public Orderlinestatuses orderLineStatuses { get; set; }
        public Refund refund { get; set; }
    }

    public class Item
    {
        public string productName { get; set; }
        public string sku { get; set; }
    }

    public class Charges
    {
        public Charge[] charge { get; set; }
    }

    public class Charge
    {
        public string chargeType { get; set; }
        public string chargeName { get; set; }
        public Chargeamount chargeAmount { get; set; }
        public Tax tax { get; set; }
    }

    public class Chargeamount
    {
        public string currency { get; set; }
        public float amount { get; set; }
    }

    public class Tax
    {
        public string taxName { get; set; }
        public Taxamount taxAmount { get; set; }
    }

    public class Taxamount
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class Orderlinequantity
    {
        public string unitOfMeasurement { get; set; }
        public string amount { get; set; }
    }

    public class Orderlinestatuses
    {
        public Orderlinestatu[] orderLineStatus { get; set; }
    }

    public class Orderlinestatu
    {
        public string status { get; set; }
        public Statusquantity statusQuantity { get; set; }
        public object cancellationReason { get; set; }
        public Trackinginfo trackingInfo { get; set; }
    }

    public class Statusquantity
    {
        public string unitOfMeasurement { get; set; }
        public string amount { get; set; }
    }

    public class Trackinginfo
    {
        public long shipDateTime { get; set; }
        public Carriername carrierName { get; set; }
        public string methodCode { get; set; }
        public string trackingNumber { get; set; }
        public string trackingURL { get; set; }
    }

    public class Carriername
    {
        public object otherCarrier { get; set; }
        public object carrier { get; set; }
    }

    public class Refund
    {
        public object refundId { get; set; }
        public string refundReason { get; set; }
        public Charges1 charges { get; set; }
    }

    public class Charges1
    {
        public Charge1[] charge { get; set; }
    }

    public class Charge1
    {
        public string chargeType { get; set; }
        public string chargeName { get; set; }
        public Chargeamount1 chargeAmount { get; set; }
        public Tax1 tax { get; set; }
    }

    public class Chargeamount1
    {
        public string currency { get; set; }
        public float amount { get; set; }
    }

    public class Tax1
    {
        public string taxName { get; set; }
        public Taxamount1 taxAmount { get; set; }
    }

    public class Taxamount1
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

}
