let popUpMenu=document.querySelector('.pop-up_menu');
let menuSign=document.querySelector('.pop-up_menu_sign');
let menuClose=document.querySelector('.menu_close');

menuSign.addEventListener('click',()=>popUpMenu.style.display='block');
menuClose.addEventListener('click',()=>popUpMenu.style.display='none');
