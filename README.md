# car_store
Car store using postman and C#
# using postman : 

-- to get the vehicles
"localpath:port/api/shop/vehicle" -- will return all vehicles from the db
"localpath:port/api/shop/vehicle/{vehicleID}"

-- to get all the make's of the vehicles
"localpath:port/api/shop/vehiclemake/" -- will return all make's of the vehicles and the id's for you to use them below

-- to get all the vehicles with that makeID
"localpath:port/api/shop/vehiclemake/30" -- will return all vehicles with that make ID

-- with POST: to create an entry in DB
-- localpath:port/api/shop/addvehicle

```JSON
BODY: {
	"DriveTypeID": 4,
	"EngineDescription": 30,
	"Make":37,
	"Model":4,
	"ConstructionYear":3,
	"VehiclePrice":1
}
```

To use EntityFramework with SQL:
-- localpath:port/api/dbcontextvehicle/
-- localpath:port/api/dbcontextvehicle/{vehicleID}
