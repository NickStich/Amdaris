import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/model/product/product';
import { ProductService } from 'src/app/service/productService/product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {

  product: Product;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService) {
    this.product = new Product();
  }

  ngOnInit() {
  }

  onSubmit() {
    this.productService.save(this.product).subscribe(result => this.gotoProductList());
  }

  gotoProductList() {
    this.router.navigate(['prdt']);
  }

}
