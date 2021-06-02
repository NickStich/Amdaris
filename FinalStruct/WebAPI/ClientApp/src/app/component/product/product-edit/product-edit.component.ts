import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/model/product/product';
import { ProductService } from 'src/app/service/productService/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: Product;
  id: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService) {
      this.product = new Product();
     }

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.productService.getById(this.id).subscribe(data => {
      this.product = data;
    });
  }

  onSubmit() {
     this.productService.update(this.id, this.product).subscribe(result => this.gotoProductList());
  }

  gotoProductList() {
    this.router.navigate(['prdt']);
  }

}
