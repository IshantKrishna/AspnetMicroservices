# AspnetMicroservices
ASP .NET based Microservices


# Docker Command
1. Open Terminal at solution location
2. > docker ps
3. > docker pull mongo  
4. Run mongo db: > dicker run -d -p 27017:27017 --name shopping-mongo mongo
5. Open container bash: > docker exec -it shopping-mongo /bin/bash
6. Mongo Bash command, show files: > ls
7. Open Mongo Shell:> Mongosh
8. to show current db's in container> show dbs
9. Create database: > use CatalogDb
10. create collection: > db.createCollection('Products')
11. Add items into collection: > db.Products.insertMany([{ 'Name':'Asus Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':54.93 }, { 'Name':'HP Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':88.93 } ])
12. Show collection: > db.Products.find({}).pretty()
13. Remove collection: > db.Products.remove({})