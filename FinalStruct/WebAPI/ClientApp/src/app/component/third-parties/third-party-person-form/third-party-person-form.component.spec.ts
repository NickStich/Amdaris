import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThirdPartyPersonFormComponent } from './third-party-person-form.component';

describe('ThirdPartyPersonFormComponent', () => {
  let component: ThirdPartyPersonFormComponent;
  let fixture: ComponentFixture<ThirdPartyPersonFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThirdPartyPersonFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThirdPartyPersonFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
