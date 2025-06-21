### 📘 FINA API - Selected Endpoints Guide

---

#### 🔗 Base URLs
- **Authentication:** `http://[IP:PORT]/api/authentication`
- **Operation:** `http://[IP:PORT]/api/operation`

---

#### 📋 Common Headers
```
Content-Type: application/json
Accept: application/json
Authorization: Bearer <your_token_here>
```

#### 📥 GET Request Headers
Use the following headers with **all GET endpoints**:
```
GET /api/operation/<endpoint>
Headers:
  Content-Type: application/json
  Accept: application/json
  Authorization: Bearer <your_token_here>
```
Replace `<your_token_here>` with the value received from the `authenticate` endpoint.
```
Content-Type: application/json
Accept: application/json
Authorization: Bearer <your_token_here>
```

---

### 🔐 Authentication
- **Endpoint:** `POST /api/authentication/authenticate`
- **Description:** Generates JWT token for authorization
- **Body:**
```json
{
  "login": "your_login", // (string) Username for API access
  "password": "your_password" // (string) Password for API access
}
```
- **Response:**
```json
{
  "token": "JWT token string", // (string) Authorization token (valid 36 hours)
  "ex": null // (string) Error message if any
}
```
- **Endpoint:** `POST /api/authentication/authenticate`
- **Description:** Generates JWT token for authorization
- **Body:**
```json
{
  "login": "your_login",
  "password": "your_password"
}
```
- **Response:**
```json
{
  "token": "JWT token string",
  "ex": null
}
```

---

### 🔧 Product Characteristics

#### getCharacteristics
- **Endpoint:** `GET /api/operation/getCharacteristics`
- **Description:** Fetches all product characteristics
- **Returns:** List of available product characteristics
- **Response Example:**
```json
{
  "characteristics": [
    {
      "id": 1, // (int) Characteristic ID
      "tag": "COLOR", // (string) Unique identifier
      "type": 0, // (byte) 0=text, 1=list
      "name": "ფერი", // (string) Default name
      "name2": "Color", // (string) English
      "name3": "Колір" // (string) Russian/Ukrainian
    }
  ],
  "ex": null
}
```
- **Endpoint:** `GET /api/operation/getCharacteristics`
- **Description:** Fetches all product characteristics
- **Response Example:**
```json
{
  "characteristics": [
    { "id": 1, "tag": "COLOR", "type": 0, "name": "ფერი" }
  ],
  "ex": null
}
```

#### getCharacteristicValues
- **Endpoint:** `GET /api/operation/getCharacteristicValues`
- **Description:** Gets all product characteristic values
- **Returns:** List of values linked to each product-characteristic pair
- **Response Example:**
```json
{
  "characteristic_values": [
    {
      "product_id": 43, // (int) ID of the product
      "characteristic_id": 1, // (int) ID of the characteristic
      "value": "შავი", // (string) Value in default language
      "value2": "black", // (string) English
      "value3": "чорний" // (string) Russian/Ukrainian
    }
  ],
  "ex": null
}
```
- **Endpoint:** `GET /api/operation/getCharacteristicValues`
- **Description:** Gets all product characteristic values
- **Response Example:**
```json
{
  "characteristic_values": [
    { "product_id": 43, "characteristic_id": 1, "value": "შავი" }
  ],
  "ex": null
}
```

---

### 📦 Product Groups

#### getProductGroups
- **Endpoint:** `GET /api/operation/getProductGroups`
- **Description:** Fetches product group hierarchy

#### getWebProductGroups
- **Endpoint:** `GET /api/operation/getWebProductGroups`
- **Description:** Fetches alternative (web) product groups

---

### 🛍️ Products

#### getProducts
- **Endpoint:** `GET /api/operation/getProducts`
- **Description:** Full product catalog
- **Returns:** List of all product items with details
- **Response Structure:**
```json
{
  "products": [
    {
      "id": 5, // (int) Product ID
      "group_id": 11, // (int) Product group ID
      "unit_id": 1, // (int) Unit of measure ID
      "code": "000111111111", // (string) Unique product code
      "name": "ანოს ასკილი", // (string) Product name
      "vat": 1, // (byte) VAT type (1=taxed, 2=zero, 3=exempt)
      "min_quantity": "3", // (string) Minimum quantity info
      "add_fields": [
        { "field": "usr_column_501", "value": "უშაქრო" }
      ]
    }
  ],
  "ex": null
}
```
- **Endpoint:** `GET /api/operation/getProducts`
- **Description:** Full product catalog

#### getProductPrices
- **Endpoint:** `GET /api/operation/getProductPrices`
- **Description:** Retrieves product pricing

#### getProductUnits
- **Endpoint:** `GET /api/operation/getProductUnits`
- **Description:** Lists additional product units

#### getProductsArray
- **Endpoint:** `POST /api/operation/getProductsArray`
- **Body:**
```json
[1, 2, 3]
```
- **Description:** Fetches specific products by ID array

#### getProductAdditionalFields
- **Endpoint:** `GET /api/operation/getProductAdditionalFields`
- **Description:** Fetches additional field metadata for products

#### getProductImages
- **Endpoint:** `GET /api/operation/getProductImages/{product}`
- **Description:** Fetches product images by product ID

#### getProductsImageArray
- **Endpoint:** `POST /api/operation/getProductsImageArray`
- **Description:** Fetches images for multiple products

#### getProductsRest
- **Endpoint:** `GET /api/operation/getProductsRest`
- **Description:** Product stock levels across stores

---

### 📤 Documented Outgoing Goods

#### getDocProductOut
- **Endpoint:** `GET /api/operation/getDocProductOut/{id}`
- **Description:** Document for outgoing product

#### getDocProductOutSingle
- **Endpoint:** `GET /api/operation/getDocProductOutSingle/{id}`
- **Description:** Document for single retail sale

---

### 🚚 Products On The Way

#### getProductsOnWay
- **Endpoint:** `GET /api/operation/getProductsOnWay`
- **Description:** Pending deliveries (products in transit)
- **Response Example:**
```json
{
  "products": [
    {
      "product_id": 101,
      "store_id": 3,
      "amount": 25,
      "doc_id": 5051,
      "doc_type": "შეკვეთა",
      "doc_date": "2024-10-20T00:00:00"
    }
  ],
  "ex": null
}
```

---

### 📦 Save Document: Product Out

#### saveDocProductOut
- **Endpoint:** `POST /api/operation/saveDocProductOut`
- **Description:** Saves a product outgoing (sale) document
- **Full Request Body Example:**
```json
{
  "id": 0,
  "date": "2018-12-08T18:00:00",
  "num_pfx": "",
  "num": 0,
  "purpose": "რელიზაცია",
  "amount": 65.7,
  "currency": "GEL",
  "rate": 1.0,
  "store": 1,
  "user": 2,
  "staff": 3,
  "project": 2,
  "customer": 8,
  "is_vat": true,
  "make_entry": true,
  "pay_type": 1,
  "price_type": 3,
  "w_type": 2,
  "t_type": 1,
  "t_payer": 2,
  "w_cost": 0.5,
  "foreign": false,
  "drv_name": "მძღოლის სახელი, გვარი",
  "tr_start": "ტრანსპორტირების დაწყების ადგილი",
  "tr_end": "ტრანსპორტირების დასრულების ადგილი",
  "driver_id": "12345678910",
  "car_num": "SAK005",
  "tr_text": "მისაბმელი/გადამზიდავი",
  "sender": "გამგზავნი/ჩამბარებელი",
  "reciever": "მიმღები",
  "comment": "კომენტარის ტექსტი",
  "overlap_type": 0,
  "overlap_amount": 0,
  "add_fields": [
    {
      "field": "usr_column_510",
      "value": "test string"
    }
  ],
  "products": [
    {
      "id": 2,
      "sub_id": 0,
      "quantity": 1.0,
      "price": 35.70
    },
    {
      "id": 3,
      "sub_id": 0,
      "quantity": 3.0,
      "price": 10.0
    }
  ],
  "services": [
    {
      "id": 20,
      "quantity": 1.0,
      "price": 2.0
    }
  ]
}
```
- **Response Example:**
```json
{
  "id": 9876,
  "ex": null
}
```json
{
  "doc": {
    "doc_type_id": 1,           // (int) Document type ID
    "doc_num": "SALE-0001",    // (string) Optional document number
    "date": "2024-11-01T00:00:00", // (string) Document date
    "store_id": 2,              // (int) Store ID
    "customer_id": 123,         // (int) Customer ID
    "price_type_id": 1,         // (int) Price type ID
    "discount_percent": 5,      // (decimal) Discount percent
    "pay_type": 1,              // (int) Payment type (e.g., 1=cash, 2=card)
    "pay_days": 0,              // (int) Payment days (for credit)
    "comment": "Quick sale",    // (string) Optional note
    "products": [
      {
        "product_id": 5,        // (int) Product ID
        "quantity": 3,          // (decimal) Quantity to sell
        "price": 9.99,          // (decimal) Unit price
        "discount": 0           // (decimal) Optional item-level discount
      }
    ]
  }
}
```
- **Response Example:**
```json
{
  "id": 9876, // (int) ID of the newly created document
  "ex": null
}
```
- **Response Example:**
```json
{
  "id": 9876, // (int) ID of the newly created document
  "ex": null
}
```

#### getProductsOnWay
- **Endpoint:** `GET /api/operation/getProductsOnWay`
- **Description:** Pending deliveries (products in transit)
