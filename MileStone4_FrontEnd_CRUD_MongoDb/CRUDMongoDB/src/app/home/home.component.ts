import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../models/product';
import { ProductCommandService } from '../services/product-command.service';
import { ProductQueryService } from '../services/product-query.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public productList:Product[]=[];

  public currId:any;

  public product:Product={
    id:"",
    productName:"",
    productCost:0,
    productQuantity:0,
    productCategory:""
  };

  public updateProduct:Product={
    id:"",
    productName:"",
    productCost:0,
    productQuantity:0,
    productCategory:""
  };

  constructor(private productQueryService: ProductQueryService,private productCommandService:ProductCommandService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getAllProduct();
  }

  getAllProduct(){
    this.productQueryService.getAllProducts().subscribe((resp)=>{
      console.log(resp);
      this.productList=resp;
    },(error:HttpErrorResponse)=>{
      alert(error.message);
    });
  }

 

  
  deleteProduct(id:string){
    
    this.currId=id;
  }

  OnDeleteProduct(){
    
    this.productCommandService.deleteProduct(this.currId).subscribe((resp)=>{
      this.getAllProduct();
    },(error:HttpErrorResponse)=>{
      alert(error.message);
    });
  }

  createProduct(addForm:NgForm){
    this.productCommandService.addProduct(this.product).subscribe((resp)=>{
      this.getAllProduct();
      addForm.reset();
    },(error:HttpErrorResponse)=>{
      alert(error.message);
    });
  }

  getProductById(currProduct: Product){

    this.updateProduct.id=currProduct.id;

  }

  onUpdate(updateForm: NgForm){

    this.productCommandService.updateProduct(this.updateProduct).subscribe((resp)=>{
      this.getAllProduct();
      
    });

  }

}
