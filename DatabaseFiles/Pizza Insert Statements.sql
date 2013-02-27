Print 'New Category'
insert into Category (CategoryName) values ('Sides')
-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'jalapeno poppers','a jalapeno pepper surrounded in cream cheese and covered in a crispy batter','portion','4.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'onion rings','crispy breaded real onion rings','portion','3.50', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Garlic Bread','Square Cheesy Garlic Pizza Bread served as fingers with our unique Buttery Garlic sauce','portion','3.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Garlic Mushrooms','Crispy Breaded Garlic Mushrooms, with our Saucy Garlic and Herb Dip','portion','4.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Potato Wedges','Crispy potato wedges sprinkled with mild flavoured herbs with our Saucy BBQ Dip','portion','3.00', 'Img1.jpg')

Print 'New Category'
insert into Category (CategoryName) values ('Dips')
-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'BBQ Dip','BBQ Dip','tub','1.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'chilli tomato dip','chilli tomato dip','tub','1.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Mayo Dip','Mayo Dip','tub','1.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Tomatoe Dip','Tomatoe Dip','tub','1.00', 'Img1.jpg')


Print 'New Category'
insert into Category (CategoryName) values ('Drinks')
-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Coca Cola','can','can','1.50', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Diet Coke','can','can','1.50', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Fanta','can','can','1.50', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'Sprite','can','can','1.50', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'7-Up','can','can','1.50', 'Img1.jpg')

Print 'New Category'
insert into Category (CategoryName) values ('Chips')
-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'cheesey chips','cheesey chips','portion','4.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'garlic cheesey chips','garlic chips smothered in chedder cheese','portion','4.00', 'Img2.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'curry chips','curry chips','portion','4.00', 'Img2.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'garlic chips','garlic chips','portion','4.00', 'Img2.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'plain chips','plain chips','portion','2.50', 'Img2.jpg')


Print 'New Category'
insert into Category (CategoryName) values ('Chicken Combos')
-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'dippers combo','chicken dippers and chips','portion','7.00', 'Img1.jpg')
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName) 
values ((select MAX(CategoryID) from Category),'buffalo combo','buffalo wings and chips','portion','7.00', 'Img2.jpg')

Print 'New Category'
insert into Category (CategoryName) values ('Pizzas')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Indian Apache','New pizza','Pizza','0', 'Img3.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Curry Sauce','Mozzarella','Tandoori Chicken, Green peppers, Onion')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Mexican Pepper Volcano','Our hottest pizza yet!','Pizza','0', 'Img4.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'BBQ sauce','Mozzarella','Chilli Shake, Beef Balls, Cajun Chicken, Green peppers, Jalapenos')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'All Day Breakfast','','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Mushrooms, Bacon, Sausage, Onion, Tomatoes')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Bacon Apache','','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Extra Cheese, Mushrooms, Bacon, Onion')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Buffalo','','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Chicken, Bacon, Ham, Pepperoni')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Cajun Apache','','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Extra Cheese, Cajun Chicken, Jalapenos, Tomatoes')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Chicken Apache','','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Sweetcorn, Mushrooms, Pineapple, Chicken')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Geronimo','','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Green peppers, Sweetcorn, Mushrooms, Pepperoni, Onion')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Hot Apache','The Hot Apache Pizza!','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Onion, Pepperoni, Jalapenos, Extra Cheese')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')

-- Add the Menu Items
insert into MenuItems (FKCategoryID, ProductName, ProductDescription, PortionSize, Price, ImageName, MultiplePricing) 
values ((select MAX(CategoryID) from Category),'Sitting Bull','','Pizza','0', 'Img5.jpg', 1)

insert into Pizza (FKMenuItemsID, Sauce, Cheese, Toppings) 
values ((select MAX(MenuItemsID) from MenuItems), 'Original','Mozzarella','Beef Balls, Salami, Steak')

insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Personal', '8.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Small', '12.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Medium', '16.00')
insert into MenuMultiPrices (FKMenuItemsID, PortionType, Price)
values ((select MAX(MenuItemsID) from MenuItems), 'Large', '21.00')



select * from Category
select * from MenuItems
select * from Pizza
select * from MenuMultiPrices