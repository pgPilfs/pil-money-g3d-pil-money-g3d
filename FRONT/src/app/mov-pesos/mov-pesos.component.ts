import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MovimientosService } from '../Services/movimientos.service';


@Component({
  selector: 'app-mov-pesos',
  templateUrl: './mov-pesos.component.html',
  styleUrls: ['./mov-pesos.component.css']
})
export class MovPesosComponent implements OnInit {
  seccionIngreso = false;
  seccionRetiro = false;
  form: any = {};
  operacionForm!: FormGroup;
  
 saldo:boolean = false ;

  constructor(private mov : MovimientosService, private fb: FormBuilder,private toastr: ToastrService) { 
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
    

    
  }

  ngOnInit(): void {
    const idcuenta = localStorage.getItem("idcuenta")||'';
    const idc = parseInt(idcuenta)
    this.operacionForm = this.fb.group({
      idCuenta: new FormControl(idc),
      idTipoOperacion: new FormControl(''),
      destinatario: new FormControl(''),
      monto: new FormControl(''),
      fechaOperacion: new FormControl(''),
    });
  }

  ingresar() {
    this.operacionForm.controls['idTipoOperacion'].setValue(2);
    this.operacionForm.controls['destinatario'].setValue(0);
    console.log(this.operacionForm.value)
    this.mov.Operaciones(this.operacionForm.value).subscribe(res=>{

      this.toastr.success('Carga Realizada');

    },err=>{
      this.toastr.error(err);
    });

  }
  retiro() {
    
    
    this.operacionForm.controls['idTipoOperacion'].setValue(1);
    this.operacionForm.controls['destinatario'].setValue(0);
    this.mov.Operaciones(this.operacionForm.value).subscribe(res=>{

      this.toastr.success('Dinero Retirado');

    },err=>{
      
        this.saldo=true
      
      
    }
    
    );


    

  }
}
