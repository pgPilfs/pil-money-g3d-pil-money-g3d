import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { MovimientosService } from '../Services/movimientos.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DatosUsuarioService } from '../Services/datos-usuario.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-transferencia-otra-cuenta',
  templateUrl: './transferencia-otra-cuenta.component.html',
  styleUrls: ['./transferencia-otra-cuenta.component.css']
})
export class TransferenciaOtraCuentaComponent implements OnInit {
  operacionForm!: FormGroup;
  destinoForm!: FormGroup;
  content:any;
  public datos: any;
  constructor(private router:Router,private mov : MovimientosService,private fb: FormBuilder,private toastr: ToastrService,private datousuario:DatosUsuarioService,private modalService: NgbModal) { 
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
    const idcuenta = localStorage.getItem("idcuenta")||'';
    const idc = parseInt(idcuenta)
    this.operacionForm = this.fb.group({
      idCuenta: new FormControl(idc),
      idTipoOperacion: new FormControl(3),
      destinatario: new FormControl(),
      monto: new FormControl('',[Validators.required]),
      fechaOperacion: new FormControl(''),
    });
    this.destinoForm = this.fb.group({
      cvu: new FormControl(''),
    });
  }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    if(id==''){
      this.router.navigateByUrl('404');
    }
    this.getDatau();
  }

  transferir(content:any){
  
    this.mov.OperacionesCuenta(this.destinoForm.controls['cvu'].value,this.operacionForm.value).subscribe(res=>{
  
      this.toastr.success('Trasferecnia Realizada');
      localStorage.removeItem("idcontacto");
      this.openVerticallyCentered(content)
    },err=>{
      this.toastr.error(err);
    });
    
  }




  //cuentaUsuario
getDatau = (): void => {
  const idcontacto: string = localStorage.getItem('idusuario')||'';
  this.datousuario.obtenercuenta(parseInt(idcontacto)).subscribe(
      (datos: any) => {
          console.log(datos)
          this.datos = datos;
      },
      (error: any) => {
          console.log(error);
      },
      () => {}
   );
}

openVerticallyCentered(content:any) {
  this.modalService.open(content, { centered: true });
}
}
