create table Recipes
(
	id int primary key identity(1, 1),
	name nvarchar(256) not null,
)

insert into Ingredients values ('Acucar')

create table RecipeIngredients 
(
	id int primary key identity(1, 1),
	recipeId int not null, 
	ingredientId int not null,
	
	FOREIGN KEY (recipeId) REFERENCES Recipes(id),
	FOREIGN KEY (ingredientId) REFERENCES Ingredients(id)
)

insert into Recipes values ('Pastel de Nata');

select * from Recipes;

insert into RecipeIngredients values (1, 1)
insert into RecipeIngredients values (1, 2)
insert into RecipeIngredients values (1, 3)

select Ingredients.id, Ingredients.name from RecipeIngredients
join Ingredients ON RecipeIngredients.ingredientId = Ingredients.id
where RecipeIngredients.recipeId = 1;

select RecipeIngredients.id, Ingredients.name from RecipeIngredients
JOIN Ingredients ON Ingredients.id = RecipeIngredients.ingredientId
where recipeId = 1;

SELECT id, name FROM Recipes WHERE id = 1;
