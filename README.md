# Net Generic Repository Example

This is a simple example of a generic repository pattern implementation. This project provides an API for managing products and categories. You can create, update, and delete categories, as well as list the products belonging to each category. Similarly, you can perform various operations related to products, such as creating, updating, and deleting them, as well as sorting products based on their prices.

## Installing

1. Clone the repository
```
git clone https://github.com/BerkayMehmetSert/net.GenericRepository.git
```

2. Install dependencies
```
dotnet restore
```

3. Create database
```
dotnet ef database update
```

4. Run the project
```
dotnet run
```

## Usage

### Categories

**Get all categories**
```bash
GET /api/category
```
Response body:
```json
[
  {
    "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
    "name": "Category 1",
    "description": "Description 1"
  },
  {
    "id": "6949cacd-f274-43fa-06be-08db508cb4eb",
    "name": "Category 2",
    "description": "Description 2"
  }
]
```

**Get category by id**
```bash
GET /api/category/{id}
```

Response body:
```json
{
  "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
  "name": "Category 1",
  "description": "Description 1"
}
```

**Get category by name**
```bash
GET /api/category/name/{name}
```

Response body:
```json
{
  "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
  "name": "Category 1",
  "description": "Description 1"
}
```

**Create category**
```bash
POST /api/category
```

Request body:
```json
{
  "name": "Category 1",
  "description": "Description 1"
}
```

**Update category**
```bash
PUT /api/category/{id}
```

Request body:
```json
{
  "name": "Category 1",
  "description": "Description 1"
}
```

**Delete category**
```bash
DELETE /api/category/{id}
```

### Products

**Get all products**
```bash
GET /api/product
```

Response body:
```json
[
  {
    "price": 110,
    "category": {
      "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
      "name": "Category 1",
      "description": "Description 1"
    },
    "id": "2d4f623a-1401-477a-f17a-08db5093ed92",
    "name": "Product 1",
    "description": "Description 1"
  },
  {
    "price": 100,
    "category": {
      "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
      "name": "Category 1",
      "description": "Description 1"
    },
    "id": "141f2ca8-6aca-4fd4-1814-08db508cc9b2",
    "name": "Product 2",
    "description": "Description 2"
  }
]
```

**Get product by id**
```bash
GET /api/product/{id}
```

Response body:
```json
{
  "price": 110,
  "category": {
	"id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
	"name": "Category 1",
	"description": "Description 1"
  },
  "id": "2d4f623a-1401-477a-f17a-08db5093ed92",
  "name": "Product 1",
  "description": "Description 1"
}
```

**Get product by name**
```bash
GET /api/product/name/{name}
```

Response body:
```json
{
  "price": 110,
  "category": {
	"id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
	"name": "Category 1",
	"description": "Description 1"
  },
  "id": "2d4f623a-1401-477a-f17a-08db5093ed92",
  "name": "Product 1",
  "description": "Description 1"
}
```

**Get products descending by price**
```bash
GET /api/product/price/descending
```

Response body:
```json
[
  {
	"price": 110,
	"category": {
	  "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
	  "name": "Category 1",
	  "description": "Description 1"
	},
	"id": "2d4f623a-1401-477a-f17a-08db5093ed92",
	"name": "Product 1",
	"description": "Description 1"
  },
  {
	"price": 100,
	"category": {
	  "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
	  "name": "Category 1",
	  "description": "Description 1"
	},
	"id": "141f2ca8-6aca-4fd4-1814-08db508cc9b2",
	"name": "Product 2",
	"description": "Description 2"
  }
]
```

**Get products ascending by price**
```bash
GET /api/product/price/ascending
```

Response body:
```json
[
  {
	"price": 100,
	"category": {
	  "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
	  "name": "Category 1",
	  "description": "Description 1"
	},
	"id": "141f2ca8-6aca-4fd4-1814-08db508cc9b2",
	"name": "Product 2",
	"description": "Description 2"
  },
  {
	"price": 110,
	"category": {
	  "id": "79613b77-5fcf-4063-4f2c-08db508b67d0",
	  "name": "Category 1",
	  "description": "Description 1"
	},
	"id": "2d4f623a-1401-477a-f17a-08db5093ed92",
	"name": "Product 1",
	"description": "Description 1"
  }
]
```

**Create product**
```bash
POST /api/product
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "categoryId": "79613b77-5fcf-4063-4f2c-08db508b67d0",
  "price": 110
}
```

**Update product**
```bash
PUT /api/product/{id}
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 110
}
```

**Update product category**
```bash
PUT /api/product/{id}/category/{categoryId}
```

**Delete product**
```bash
DELETE /api/product/{id}
```
