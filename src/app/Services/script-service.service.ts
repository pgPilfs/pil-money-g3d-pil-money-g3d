import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ScriptServiceService {

  constructor() { }

  Carga(archivos:string[]){
    for(let archivo of archivos){
      let script = document.createElement("script");
      script.src = "./assets/js/" + archivo + ".js";
      let body = document.getElementsByTagName("body")[0];
      body.appendChild(script);
    }
  }
}
