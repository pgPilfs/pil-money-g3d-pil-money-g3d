import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../Services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
// export class LoginComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }
  export class LoginComponent {
  loginForm: FormGroup;
  invalidLogin:boolean = false ;
  constructor(private logincomp:LoginService, private router:Router) {
    this.loginForm = new FormGroup({
      nombreusuario: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });
  }

  login() {
    if (this.loginForm.valid) {
      this.logincomp.loginpost(this.loginForm.value).subscribe(response =>{
        console.log(response);
        const token = (<any> response).token;
        const idusuario = (<any> response).id;
        const idcuenta = (<any> response).idcuenta;
        localStorage.setItem("jwt",token);
        localStorage.setItem("idusuario",idusuario);
        localStorage.setItem("idcuenta",idusuario);
        this.router.navigate(['paginaprincipal/inicio']);
      },err =>{

          this.invalidLogin=true;

      });
     
    }
  }
  

}
