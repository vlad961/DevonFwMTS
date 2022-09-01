use my_thai_star_progress
db.Dish.aggregate([
    {
        $lookup: {
            from: "Image",
            localField: "IdImage",    // field in the orders collection
            foreignField: "_id",  // field in the items collection
            as: "IdImage"
        },
    },
    { $set: { Image: "$IdImage" } },
    { $out: { db: "my_thai_star_progress", coll: "Dish" } },
])
db.Image.drop(),

    db.DishCategory.aggregate([
        {
            $lookup: {
                from: "Category",
                localField: "IdCategory",
                foreignField: "_id",
                as: "Category"
            }
        },

        { $out: { db: "my_thai_star_progress", coll: "DishCategory" } },

    ])

db.Category.drop(),


    db.Dish.aggregate([
        {
            $lookup: {
                from: "DishCategory",
                localField: "_id",
                foreignField: "IdDish",
                as: "Category"
            }
        },
        { $set: { Category: "$Category.Category" } },
        { $out: { db: "my_thai_star_progress", coll: "Dish" } },
    ])
db.DishCategory.drop()
db.Dish.updateMany({}, { "$unset": { "IdImage": "" } })
