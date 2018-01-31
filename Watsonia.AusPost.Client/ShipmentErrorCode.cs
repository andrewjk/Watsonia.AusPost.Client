using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public enum ShipmentErrorCode
	{
		/// <summary>
		/// No error.
		/// </summary>
		None,
		/// <summary>
		/// The input request is missing the mandatory field with the name 'FIELD NAME'. Please resubmit the request including the required fields and values. 
		/// </summary>
		JsonMandatoryFieldMissing = 40002,
		/// <summary>
		/// Customer information for the submitted customer identifier ACCOUNT could not be found. For further assistance please contact your Account Manager or call Australia Post on 13 21 31. 
		/// </summary>
		CustomerNotFound = 41001,
		/// <summary>
		/// The postcode POSTCODE submitted for the sender "from" address does not match the lodgement postcode POSTCODE the contract. Please change the sender "from" postcode to match the lodgement postcode in the contract and attempt the request again. 
		/// </summary>
		FromPostCodeDoesNotMatchContractOriginPostCode = 41007,
		/// <summary>
		/// The service CODE is not available based upon the information submitted.
		/// </summary>
		NoPricesForProduct = 42002,
		/// <summary>
		/// Maximum width must not exceed 105 cm.
		/// </summary>
		MaxWidth = 42006,
		/// <summary>
		/// Maximum height must not exceed 105 cm.
		/// </summary>
		MaxHeight = 42007,
		/// <summary>
		/// Maximum length must not exceed 105 cm.
		/// </summary>
		MaxLength = 42008,
		/// <summary>
		/// Maximum volume must not exceed 0.25 m3.
		/// </summary>
		MaxVolume = 42009,
		/// <summary>
		/// Maximum weight must not exceed 10000 kg
		/// </summary>
		MaxWeight = 42010,
		/// <summary>
		/// At least 2 dimensions must be 5 cm.
		/// </summary>
		TwoDimensionsLessThan5cm = 42011,
		/// <summary>
		/// The product CODE you have entered is not available on your contract ACCOUNT for the destination postcode POSTCODE. For further assistance, please contact your Account Manager or call Australia Post on 13 21 31.
		/// </summary>
		ProductNotSupportedByContractError = 42012,
		/// <summary>
		/// The service CODE is not available based upon the submitted weight of WEIGHT kg.
		/// </summary>
		UnableToCalculatePriceForWeight = 43003,
		/// <summary>
		/// The service CODE is not available based upon the calculated cubic weight of WEIGHT kg for the submitted dimensions and weight. 
		/// </summary>
		UnableToCalculatePriceForDimensions = 43004,
		/// <summary>
		/// The shipment with reference REFERENCE includes a business name for the "to" address that exceeds the maximum limit of 50 characters. Please change the business name to have less than 50 characters and submit the request again. 
		/// </summary>
		MaxLengthDestinationBusinessName = 43008,
		/// <summary>
		/// A value for customer reference 1 or 2 exceeds the maximum limit of 50 characters. Please reduce the length of the value and submit the request again. 
		/// </summary>
		MaxLengthCustomerReferenceText = 43009,
		/// <summary>
		/// A value for delivery instructions exceeds the maximum limit of 128 characters. Please reduce the length of the value and submit the request again. 
		/// </summary>
		MaxLengthDeliveryInstruction = 43011,
		/// <summary>
		/// The request contains shipments with items that are missing barcode ids. Please add barcode ids to the items where the ids are missing, and resubmit your request. 
		/// </summary>
		AllOrNoneShipmentNoError = 43017,
		/// <summary>
		/// The product CODE specified in an item has indicated that dangerous goods will be included in the parcel, however, the product does not allow dangerous goods to be sent using the service. Please choose a product that allows dangerous goods to be included within the parcel to be sent. 
		/// </summary>
		DangerousGoodsNotSupportedByProductError = 44003,
		/// <summary>
		/// A value for merchant reference exceeds the maximum limit of 50 characters. Please reduce the length of the value and submit the request again. 
		/// </summary>
		MaxLengthMerchantReferenceText = 44010,
		/// <summary>
		/// The shipment with shipment id SHIPMENT you requested can not be found. Please check the shipment id requested and submit the request again. 
		/// </summary>
		ShipmentNotFoundError = 44013,
		/// <summary>
		/// There are no shipments in the request to dispatch.
		/// </summary>
		NoShipmentToDispatch = 44015,
		/// <summary>
		/// The shipment SHIPMENT cannot be modified or included in a new order, as the shipment is already contained in an existing order. 
		/// </summary>
		ShipmentInitiated = 44016,
		/// <summary>
		/// The shipment SHIPMENT cannot be modified or included in a new order, as the shipment is contained in an order currently being finalized. 
		/// </summary>
		ShipmentInProgress = 44017,
		/// <summary>
		/// The request contains shipments with items that are missing a tracking identifier field. Please ensure that each item contains values for the fields consignment_id, article_id, and barcode_id, and resubmit your request. 
		/// </summary>
		AllOrNoneAusPostIDError = 44022,
		/// <summary>
		/// Maximum number of item in one manifest request must not exceed 2000.
		/// </summary>
		MaxItemCountError = 44031,
		/// <summary>
		/// The shipment with shipment id SHIPMENT you requested can not be found. Please check the shipment id requested and submit the request again.
		/// </summary>
		NoShipmentInRequestError = 44033,
		/// <summary>
		/// The shipment with shipment id SHIPMENT does not belong to the contract with account number ACCOUNT. Please process the shipment which belongs to only one contract defined by the account number in the request.
		/// </summary>
		ShipmentNotWithContractError = 44038,
		/// <summary>
		/// The product PRODUCT is a flat-rate product and must not include weight or dimensions. 
		/// </summary>
		ItemDimensionWeightNotApplicableError = 44043,
		ShipmentIncompleteToDispatch = 44044,
		/// <summary>
		/// These labels have been generated via a different service. You are only able to reprint these labels using the same service.
		/// </summary>
		/// <remarks>
		/// This error means the API has detected that you've created labels using a system other than the API (for example your own system). If you provide tracking_details when you create a shipment, the API assumes you have created labels using a different service. 
		/// </remarks>
		CreateLabelErrorDifferentPrintingService = 51015,
		/// <summary>
		/// An unknown error occurred.
		/// </summary>
		Unknown
	}
}
