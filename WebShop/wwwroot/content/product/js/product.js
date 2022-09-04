let imagesProduct=document.querySelectorAll('.product_photo');
let mainImage=document.getElementById('main_photo');
imagesProduct.forEach(element => element.addEventListener('click',()=> mainImage.src=element.src));