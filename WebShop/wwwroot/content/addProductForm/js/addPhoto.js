let fileInput=document.getElementById('input__file');
let mainPhoto=document.getElementById('main_photo');
let smallPhotos=document.getElementsByClassName('product_photo');
let nameText=document.getElementById('product_name');
let productPrice=document.getElementById('product_price');
let description=document.getElementById('product_description');
let btnSend=document.getElementById('btn-send');
let countEl=document.getElementById('product_count');
const len=4;

description.addEventListener('input',checkState);
productPrice.addEventListener('input',checkState);
nameText.addEventListener('input',checkState);

fileInput.onchange=function(){
    if (!this.files)
    return;

    if (this.files.length===len)
    {   
        mainPhoto.src=URL.createObjectURL(this.files[0]);

        for (let i=0; i<len; i++)
        {
            smallPhotos[i].src=URL.createObjectURL(this.files[i]);
        }
        return;
    }

    alert('Error');  
}

function isEmpty(str) //true if empty
{
    return str.trim().length===0;
}
function checkState()
{   
    if (isEmpty(nameText.value) || isEmpty(description.value) || isEmpty(productPrice.value) || isEmpty(countEl.value) || fileInput.files.length!==len)
    {   
        btnSend.disabled=true;
        return;
    }
    btnSend.disabled=false;

}
