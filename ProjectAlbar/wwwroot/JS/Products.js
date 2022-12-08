window.addEventListener("load", (event) => {
    getProduct();
});

function getProduct() {
    fetch("../api/products/")
        .then((response) => {
            if (response.ok && response.status == 200) return response.json();
        })
        .then((data) => {
            if (data) {
                data.forEach((p) => drowProduct(p));
            } else {
                alert("we dont have a products");
            }
        });
}

function drowProduct(product) {
    var ul = document.getElementById('products-list')
    ul.insertAdjacentHTML('afterbegin',
        ` <li id=${product.ProductId} class="product-item"
                  <div class="product-category">${product.category} :קטגוריה</div>
                  <div class="product-name">${product.productName}</div>               
                  <div class="product-price">${product.price}$ :מחיר </div>
            </li>`)
}

function getCategory() {
    fetch("../api/category/")
        .then((response) => {
            if (response.ok && response.status == 200) return response.json();
        })
        .then((data) => {
            if (data) {
                var CategoryArray = data;
                data.forEach((c) => drowCategory(c));
            } else {
                alert("we dont have a categories");
            }
        });
}

function drowCategory(category) {
    var elmnt = document.getElementById("temp-category");
    var cln = elmnt.content.cloneNode(true);
    cln.querySelector(".OptionName").innerText = category.categoryName;
    cln.querySelector(".opt").id = category.categoryId;
    cln.querySelector(".lbl").for = category.categoryId;
    cln.querySelector(".opt").addEventListener("change", () => {
        if (document.getElementById(category.categoryId).checked)
            getProductByCategory(category.categoryId);
        
    });
    document.getElementById("filters").appendChild(cln);
}

function getProductByCategory(string) {
    fetch("../api/products/" + id)
        .then((response) => {
            if (response.ok && response.status == 200) return response.json();
        })
        .then((data) => {
            if (data) {
                document.body.removeChild(document.getElementById("ProductList"));
                c = 0;
                document.getElementById("counter").innerHTML = 0;
                var d = document.createElement("div");
                d.setAttribute("id", "ProductList");
                document.body.appendChild(d);
                data.forEach((p) => drowProduct(p));
            } else {
                alert("you need to application");
            }
        });
}


function addProduct() {
    var pName = document.getElementById('product-name').value;
    var pprice = document.getElementById('product-price').value;
    var productObj = { productName: pName, productPrice:  pPrice}
}

function searchProduct() {
    clear()//קודם שימחק את הסינון הקודם ואז יתחיל סינון חדש
    const searchValue = document.getElementById("search-field").value.toLowerCase();
    ul = document.getElementById("products-list");
    productsList = ul.getElementsByTagName("li");
    for (var i = 0; i < productsList.length; i++) {
        var productText = productsList[i].innerText.replace(/[^a-zA-Z0-9]/g, '');
        console.log("prdoucttext",productText)
        if (productText.toLowerCase().includes(searchValue.trim()) == false) {
            //אל תציג את המוצר הזה 
            productsList[i].style.display = "none";
        } else {
            productsList[i].style.display = "";
        }
    }
}
//פונקציה לניקוי הסינון של החיפוש
function clear() {
    ul = document.getElementById("products-list");
    productsList = ul.getElementsByTagName("li");
    for (var i = 0; i < productsList.length; i++) {
        productsList[i].style.display = "";
    }
}

function clearAllClick() {
    document.getElementById("search-field").value = "";
    clear();
}

function addProductClick(e) {
    e.preventDefault();
    var formDiv = document.getElementById('addProductContainer');
    formDiv.style.display = "";
    var hiddenDiv = document.getElementById('hiddenContainer');
    hiddenDiv.style.display = "none";
    console.log(formDiv)
}

function createP(event) {
    event.preventDefault();
    console.log("price", document.getElementById("price").value)
    fetch('../api/Products/CreateProduct', {
        headers: {
            'Content-Type': 'application/json',
        },
        method: 'POST',
        body: JSON.stringify({
            ProductName: document.getElementById("productName").value,
            Category: document.getElementById("productCategory").value,
            Price: +document.getElementById("price").value,
            UnitsInStock: +document.getElementById("unitStoke").value,
        }),
    })
        .then(response => response.json())
        .then(data => {
            if (data)
                window.location.href = "Product.html";
        });
}
