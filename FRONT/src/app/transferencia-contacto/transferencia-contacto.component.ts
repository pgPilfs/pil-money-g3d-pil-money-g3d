import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { MovimientosService } from '../Services/movimientos.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DatosUsuarioService } from '../Services/datos-usuario.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Content } from '@angular/compiler/src/render3/r3_ast';

@Component({
  selector: 'app-transferencia-contacto',
  templateUrl: './transferencia-contacto.component.html',
  styleUrls: ['./transferencia-contacto.component.css']
})
export class TransferenciaContactoComponent implements OnInit {

  @Input() idcontacto:number =0; 
  operacionForm!: FormGroup;
  contactoForm!: FormGroup;
  content:any;
  public datos: any;
  constructor(private router:Router,private mov : MovimientosService,private fb: FormBuilder,private toastr: ToastrService,private datousuario:DatosUsuarioService,private modalService: NgbModal) { 
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
    const idcuenta = localStorage.getItem("idcuenta")||'';
    const idc = parseInt(idcuenta)
    const idcontacto = localStorage.getItem("idcontacto")||'';
    const idcontac = parseInt(idcontacto)
    this.operacionForm = this.fb.group({
      idCuenta: new FormControl(idc),
      idTipoOperacion: new FormControl(3),
      destinatario: new FormControl(idcontac),
      monto: new FormControl('',[Validators.required]),
      fechaOperacion: new FormControl(''),
    });
  }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    if(id==''){
      this.router.navigateByUrl('404');
    }
    this.getData();
    this.getDatau();
  }
transferir(content:any){
  
  this.mov.Operaciones(this.operacionForm.value).subscribe(res=>{

    this.toastr.success('Trasferecnia Realizada');
    localStorage.removeItem("idcontacto");
    this.openVerticallyCentered(content)
  },err=>{
    this.toastr.error(err);
  });
  
}

//Cuenta contacto
getData = (): void => {
  const idcontacto: string = localStorage.getItem('idcontacto')||'';
  this.datousuario.obtenercuenta(parseInt(idcontacto)).subscribe(
      (response: any) => {
          console.log(response)
          this.initForm(response);
      },
      (error: any) => {
          console.log(error);
      },
      () => {}
   );
}

initForm(data:any){
this.contactoForm = this.fb.group({
alias: [data.alias],
cvu: [data.cvu],
banco: ['PIPAYWALLET'],
monto: data.monto,
})
    
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
