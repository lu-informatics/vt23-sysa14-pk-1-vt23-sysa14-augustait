using Connection;


DataAccessLayer dal = new DataAccessLayer();

dal.printallProducts();
dal.insertProduct(16, "Blåbär", 20.00, 2);
dal.deleteProduct(15);
