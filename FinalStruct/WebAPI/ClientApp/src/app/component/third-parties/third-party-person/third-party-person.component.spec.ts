import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThirdPartyPersonComponent } from './third-party-person.component';

describe('ThirdPartyPersonComponent', () => {
  let component: ThirdPartyPersonComponent;
  let fixture: ComponentFixture<ThirdPartyPersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThirdPartyPersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThirdPartyPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
