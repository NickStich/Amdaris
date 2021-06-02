import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { Product } from 'src/app/model/product/product';
import { ProductService } from 'src/app/service/productService/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

   products: Product[] = [];

   constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.findAll().subscribe(data => this.products = data);
  }

  deleteClick(productId) {
    this.productService.delete(productId).subscribe();
    this.refreshPage();
  }

  refreshPage() {
    window.location.reload();
  }

}
