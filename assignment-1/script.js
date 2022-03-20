var arr = [];

var basvuru = {
    isim: "",
    email: "",
    yas: "",
    universite: "",
    bolum: "",
    sinif: "",
    sehir: "",
    bootcamp_katilim: "",
    hobiler: ""
};


// console.log(1);
function onSubmit() {
  // console.log(2);
  alert("submitted");
  let bootcamp = ""; 
  basvuru.isim = document.getElementById("name").value;
  basvuru.email = document.getElementById("email").value;
  basvuru.yas = document.getElementById("age").value;
  basvuru.universite = document.getElementById("university").value;
  basvuru.bolum = document.getElementById("department").value;
  basvuru.sinif = document.getElementById("grade-choice").value;
  basvuru.sehir = document.getElementById("city").value;
  for(let i = 0; i < 4; i++) {
    bootcamp =  document.getElementsByName("bootcamp")[i].checked;
    if(bootcamp){
      basvuru.bootcamp_katilim = document.getElementsByName("bootcamp")[i].value;
      break;
    } 
  }
  i = 0;

  basvuru.hobiler = document.getElementById("hobby").value;
  // console.log(basvuru.isim);
  arr.push(basvuru);
  console.log(basvuru.isim + ", " + basvuru.bootcamp_katilim);
  basvuru = {
    isim: "",
    email: "",
    yas: "",
    universite: "",
    bolum: "",
    sinif: "",
    sehir: "",
    bootcamp_katilim: "",
    hobiler: ""
};
  // console.log(arr);
}
// console.log(3);